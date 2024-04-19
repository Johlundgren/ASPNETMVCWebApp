using Infrastructure.Entities;

namespace Infrastructure.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool IsBestSeller { get; set; }
    public string? LikesInNumbers { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Author { get; set; }
    public string? ImageUrl { get; set; }
    public string? BigImageUrl { get; set; }
    public string? Category { get; set; }

    public ICollection<SavedCourseEntity> SavedCourses { get; set; } = new List<SavedCourseEntity>();
}
