namespace TeamTaskPro.Web.Models;

public static class ApplicationRoles
{
    public const string Administrator = "Administrator";
    public const string ProjectManager = "ProjectManager";
    public const string TeamMember = "TeamMember";
    
    public static readonly IReadOnlyList<string> AllRoles = new[]
    {
        Administrator,
        ProjectManager,
        TeamMember
    };
} 