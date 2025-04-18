using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamTaskPro.Web.Models;

namespace TeamTaskPro.Web.Controllers;

[Authorize]
public abstract class BaseController : Controller
{
    protected bool IsAdmin => User.IsInRole(ApplicationRoles.Administrator);
    protected bool IsProjectManager => User.IsInRole(ApplicationRoles.ProjectManager);
    protected bool IsTeamMember => User.IsInRole(ApplicationRoles.TeamMember);
} 