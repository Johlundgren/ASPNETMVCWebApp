using Infrastructure.Models;

namespace ASPNETMVCWebApp.ViewModels;

public class CourseViewModel
{
    //public bool Succeeded { get; set; }
    public IEnumerable<Category>? Categories { get; set; }
    public IEnumerable<Course>? Courses { get; set; }
}
