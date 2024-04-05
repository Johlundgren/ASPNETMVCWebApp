
using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Services;

    public class CourseService(HttpClient http, IConfiguration configuration)
    {
        private readonly HttpClient _http = http;
        private readonly IConfiguration _configuration = configuration;


        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            var response = await _http.GetAsync($"https://localhost:7226/api/courses?key={_configuration["ApiKey:Secret"]}");
            if (response.IsSuccessStatusCode)
            {
                var courses = JsonConvert.DeserializeObject<IEnumerable<Course>>(await response.Content.ReadAsStringAsync());
                return courses ??= null!;
            }
            return null!;
        }
    }

