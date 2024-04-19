

using Infrastructure.Models;

namespace Infrastructure.Entities;

public class SavedCourseEntity
{
    public string UserId { get; set; } = null!;
    public int CourseId { get; set; }

    public virtual UserEntity User { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;
}
