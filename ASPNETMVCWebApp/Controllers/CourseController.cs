using ASPNETMVCWebApp.ViewModels;
using Azure;
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace ASPNETMVCWebApp.Controllers;

[Authorize]
public class CourseController(CategoryService categoryService, CourseService courseService, IHttpClientFactory httpClientFactory, IConfiguration configuration) : Controller
{
    private readonly CategoryService _categoryService = categoryService;
    private readonly CourseService _courseService = courseService;
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly IConfiguration _configuration = configuration;
    private readonly UserManager<UserEntity> _userManager;
    private readonly AppDbContext _context;

    public async Task<IActionResult> Courses(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {
        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {
            var courseResult = await _courseService.GetCoursesAsync(token, category, searchQuery, pageNumber, pageSize);

            var viewModel = new CourseViewModel
            {
                Categories = await _categoryService.GetCategoriesAsync(token),
                Courses = courseResult.Courses,
                Pagination = new Pagination
                {
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    TotalPages = courseResult.TotalPages,
                    TotalItems = courseResult.TotalItems
                }
            };

            return View(viewModel);
        }
        return View("Unauthorized");
    }

    public async Task<IActionResult> Details(int id)
    {
        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var apiKey = _configuration["ApiKey:Secret"];
            var response = await client.GetAsync($"https://localhost:7226/api/courses/{id}?key={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                var course = JsonConvert.DeserializeObject<Course>(await response.Content.ReadAsStringAsync());

                return View(course);
            }
        }
        return View("Unauthorized");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SaveCourse(int courseId)
    {
        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {
            bool result = await _courseService.SaveCourse(User.Identity.Name, courseId, token);

            if (result)
            {
                TempData["SuccessMessage"] = "Course saved successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to save the course.";
                return View("Error404");
            }
        }
        return View("Unauthorized");
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> SavedCourses()
    {
        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var savedCourses = await _courseService.GetSavedCourses(userId, token);

            var viewModel = new SavedCoursesViewModel
            {
                SavedCourses = savedCourses
            };

            return View(viewModel);
        }
        return View("Unauthorized");
    }
}
