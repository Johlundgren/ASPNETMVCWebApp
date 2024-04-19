using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Infrastructure.Models;
using Azure;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Contexts;

namespace Infrastructure.Services
{
    public class CourseService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        private readonly IHttpClientFactory _clientFactory = clientFactory;
        private readonly IConfiguration _configuration = configuration;
        private readonly AppDbContext _context;

        public async Task<CourseResult> GetCoursesAsync(string accessToken, string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
        {

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var apiKey = _configuration["ApiKey:Secret"];
            var response = await client.GetAsync($"https://localhost:7226/api/courses?key={apiKey}&category={category}&searchQuery={searchQuery}&pageNumber={pageNumber}&pageSize={pageSize}");
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CourseResult>(await response.Content.ReadAsStringAsync());
                if (result != null && result.Succeeded)
                    return result;
            }
            return null!;
        }

        public async Task<bool> SaveCourse(string userId, int courseId, string accessToken)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.PostAsync($"https://localhost:7226/api/courses/save/{courseId}", null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Course>> GetSavedCourses(string userId, string accessToken)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var apiKey = _configuration["ApiKey:Secret"];
            var response = await client.GetAsync($"https://localhost:7226/api/savedcourses?userId={userId}&key={apiKey}");
            if (response.IsSuccessStatusCode)
            {
                var coursesData = await response.Content.ReadAsStringAsync();
                var savedCourses = JsonConvert.DeserializeObject<List<Course>>(coursesData);
                return savedCourses;
            }
            return new List<Course>();
        }
    }
}