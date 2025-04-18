using Microsoft.EntityFrameworkCore;
using TeamTaskPro.Web.Data;
using TeamTaskPro.Web.Models;
using Xunit;

namespace TeamTaskPro.Tests.Data;

public class ApplicationDbContextTests
{
    private readonly DbContextOptions<ApplicationDbContext> _options;

    public ApplicationDbContextTests()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
    }

    [Fact]
    public async Task CanCreateAndRetrieveTaskItem()
    {
        // Arrange
        using var context = new ApplicationDbContext(_options);
        
        var task = new TaskItem
        {
            Title = "Test Task",
            Description = "This is a test task",
            Priority = TaskPriority.High,
            Status = TaskItemStatus.Open
        };

        // Act
        context.Tasks.Add(task);
        await context.SaveChangesAsync();

        // Assert
        var retrievedTask = await context.Tasks.FirstOrDefaultAsync(t => t.Title == "Test Task");
        Assert.NotNull(retrievedTask);
        Assert.Equal("Test Task", retrievedTask.Title);
        Assert.Equal(TaskPriority.High, retrievedTask.Priority);
        Assert.Equal(TaskItemStatus.Open, retrievedTask.Status);
    }

    [Fact]
    public async Task CanAddCommentToTask()
    {
        // Arrange
        using var context = new ApplicationDbContext(_options);
        
        var task = new TaskItem
        {
            Title = "Task with Comment",
            Description = "This task will have a comment"
        };

        var comment = new Comment
        {
            Content = "This is a test comment",
            TaskItem = task
        };

        // Act
        context.Tasks.Add(task);
        context.Comments.Add(comment);
        await context.SaveChangesAsync();

        // Assert
        var retrievedTask = await context.Tasks
            .Include(t => t.Comments)
            .FirstOrDefaultAsync(t => t.Title == "Task with Comment");
        
        Assert.NotNull(retrievedTask);
        Assert.Single(retrievedTask.Comments);
        Assert.Equal("This is a test comment", retrievedTask.Comments.First().Content);
    }

    [Fact]
    public async Task CanAddAttachmentToTask()
    {
        // Arrange
        using var context = new ApplicationDbContext(_options);
        
        var task = new TaskItem
        {
            Title = "Task with Attachment",
            Description = "This task will have an attachment"
        };

        var attachment = new Attachment
        {
            FileName = "test.txt",
            FilePath = "/uploads/test.txt",
            TaskItem = task
        };

        // Act
        context.Tasks.Add(task);
        context.Attachments.Add(attachment);
        await context.SaveChangesAsync();

        // Assert
        var retrievedTask = await context.Tasks
            .Include(t => t.Attachments)
            .FirstOrDefaultAsync(t => t.Title == "Task with Attachment");
        
        Assert.NotNull(retrievedTask);
        Assert.Single(retrievedTask.Attachments);
        Assert.Equal("test.txt", retrievedTask.Attachments.First().FileName);
    }
} 