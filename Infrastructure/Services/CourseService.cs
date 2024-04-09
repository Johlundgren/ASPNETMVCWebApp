using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Infrastructure.Models;
using Azure;

namespace Infrastructure.Services
{
    public class CourseService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        private readonly IHttpClientFactory _clientFactory = clientFactory;
        private readonly IConfiguration _configuration = configuration;

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
    }
}
//if (response.IsSuccessStatusCode)
//{
//    var content = await response.Content.ReadAsStringAsync();
//    var result = JsonConvert.DeserializeObject<CourseResult>(content);
//    if (result != null && result.Succeeded)
//    {
//        return result.Courses ?? new List<Course>();
//    }
//}
