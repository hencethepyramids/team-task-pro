using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamTaskPro.Web.Models;

public class Comment
{
    public Comment()
    {
        Content = string.Empty;
        TaskItem = new TaskItem();
        Author = new TeamMember();
    }

    public int Id { get; set; }

    [Required]
    [StringLength(1000)]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int TaskItemId { get; set; }
    public virtual TaskItem TaskItem { get; set; } = null!;

    public string? AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    public virtual TeamMember? Author { get; set; }
} 