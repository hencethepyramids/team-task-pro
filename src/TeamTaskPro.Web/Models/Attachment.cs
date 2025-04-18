using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamTaskPro.Web.Models;

public class Attachment
{
    public int Id { get; set; }

    [Required]
    public string FileName { get; set; } = string.Empty;

    [Required]
    public string FilePath { get; set; } = string.Empty;

    public string? ContentType { get; set; }

    public long FileSize { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public int TaskItemId { get; set; }
    public virtual TaskItem TaskItem { get; set; } = null!;

    public string? UploaderId { get; set; }

    [ForeignKey("UploaderId")]
    public virtual TeamMember? Uploader { get; set; }
} 