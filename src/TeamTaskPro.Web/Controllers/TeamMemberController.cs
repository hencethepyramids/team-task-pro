using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamTaskPro.Web.Data;
using TeamTaskPro.Web.Models;

namespace TeamTaskPro.Web.Controllers;

[Authorize]
public class TeamMemberController : BaseController
{
    private readonly ApplicationDbContext _context;

    public TeamMemberController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: TeamMember
    public async Task<IActionResult> Index()
    {
        return View(await _context.TeamMembers.ToListAsync());
    }

    // GET: TeamMember/Details/5
    public async Task<IActionResult> Details(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teamMember = await _context.TeamMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (teamMember == null)
        {
            return NotFound();
        }

        return View(teamMember);
    }

    // GET: TeamMember/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TeamMember/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,Department,Position")] TeamMember teamMember)
    {
        if (ModelState.IsValid)
        {
            _context.Add(teamMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(teamMember);
    }

    // GET: TeamMember/Edit/5
    public async Task<IActionResult> Edit(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teamMember = await _context.TeamMembers.FindAsync(id);
        if (teamMember == null)
        {
            return NotFound();
        }
        return View(teamMember);
    }

    // POST: TeamMember/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Department,Position")] TeamMember teamMember)
    {
        if (id != teamMember.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(teamMember);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(teamMember.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(teamMember);
    }

    // GET: TeamMember/Delete/5
    public async Task<IActionResult> Delete(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teamMember = await _context.TeamMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (teamMember == null)
        {
            return NotFound();
        }

        return View(teamMember);
    }

    // POST: TeamMember/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var teamMember = await _context.TeamMembers.FindAsync(id);
        if (teamMember != null)
        {
            _context.TeamMembers.Remove(teamMember);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TeamMemberExists(string id)
    {
        return _context.TeamMembers.Any(e => e.Id == id);
    }
} 