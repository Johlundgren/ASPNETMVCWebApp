using Infrastructure.Models;

namespace ASPNETMVCWebApp.ViewModels;

public class CourseViewModel
{
    public IEnumerable<Category>? Categories { get; set; }
    public IEnumerable<Course>? Courses { get; set; }
    public Pagination? Pagination { get; set; }
}
