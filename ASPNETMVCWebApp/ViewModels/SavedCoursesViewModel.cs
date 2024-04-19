using Infrastructure.Models;

namespace ASPNETMVCWebApp.ViewModels;

public class SavedCoursesViewModel
{
    public List<Course> SavedCourses { get; set; }

    public ProfileInfoViewModel? ProfileInfo { get; set; }
}
