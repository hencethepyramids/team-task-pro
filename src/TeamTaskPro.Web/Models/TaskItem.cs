using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TeamTaskPro.Web.Models;

public class TaskItem
{
    public TaskItem()
    {
        Title = string.Empty;
        Description = string.Empty;
        Status = TaskItemStatus.Open;
        Comments = new List<Comment>();
        Attachments = new List<Attachment>();
    }

    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public string? Category { get; set; }

    public TaskPriority Priority { get; set; }

    public TaskItemStatus Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? DueDate { get; set; }

    public string? AssigneeId { get; set; }

    [ForeignKey("AssigneeId")]
    public virtual TeamMember? Assignee { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}

public enum TaskPriority
{
    Low,
    Medium,
    High
}

public enum TaskItemStatus
{
    Open,
    InProgress,
    Closed
} 