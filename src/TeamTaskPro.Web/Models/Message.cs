using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamTaskPro.Web.Models;

public class Message
{
    public int Id { get; set; }

    [Required]
    public string Content { get; set; } = string.Empty;

    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; }

    public string? SenderId { get; set; }

    [ForeignKey("SenderId")]
    public virtual TeamMember? Sender { get; set; }

    public string? ReceiverId { get; set; }

    [ForeignKey("ReceiverId")]
    public virtual TeamMember? Receiver { get; set; }
} 