using ASPNETMVCWebApp.ViewModels;
using Azure;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace ASPNETMVCWebApp.Controllers;

[Authorize]
public class CourseController(CategoryService categoryService, CourseService courseService) : Controller
{
    private readonly CategoryService _categoryService = categoryService;
    private readonly CourseService _courseService = courseService;

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

    //public async Task<IActionResult> Details(int id)
    //{
    //    if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
    //    {
    //        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    //        var response = await _http.GetAsync($"https://localhost:7226/api/courses/{id}?key={_configuration["ApiKey:Secret"]}");
    //        if (response.IsSuccessStatusCode)
    //        {
    //            var course = JsonConvert.DeserializeObject<Course>(await response.Content.ReadAsStringAsync());

    //            return View(course);
    //        }
    //    }
    //    return View();
    //}
}


//public class CourseController(CategoryService categoryService, CourseService courseService) : Controller
//{
//    private readonly CategoryService _categoryService = categoryService;
//    private readonly CourseService _courseService = courseService;

//    public async Task<IActionResult> Courses(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
//    {
//        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
//        {
//            var viewModel = new CourseViewModel
//            {
//                Categories = await _categoryService.GetCategoriesAsync(token),
//                Courses = await _courseService.GetCoursesAsync(token, category, searchQuery),

//            };

//            return View(viewModel);
//        }
//        return View("Unauthorized");
//    }