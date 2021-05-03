using CapstonTask.Data;
using CapstonTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstonTask.Controllers
{
    [Authorize]
    public class TaskToDoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TaskToDoController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private string GetUserId()
        {
            return _userManager.GetUserId(User);
        }

        public async Task<IActionResult> Index()
        {
            string userId = GetUserId();
            return View(await _context.ToDos.Where(_ => _.User.Id == userId).ToListAsync());
        }

        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskToDo taskToDo)
        {
            if (ModelState.IsValid)
            {
                taskToDo.User = await _userManager.GetUserAsync(User);

                _context.ToDos.Add(taskToDo);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(taskToDo);
        }
    }
}
