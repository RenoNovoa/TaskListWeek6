using CapstonTask.Data;
using CapstonTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CapstonTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger /*ApplicationDbContext context*/)
        {
            _logger = logger;
           // _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize] //This is added to prevent somebody using the account
        public IActionResult Privacy()
        {
            var model = new EmailViewModel
            {
                UserEmail = User.Identity.Name
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
