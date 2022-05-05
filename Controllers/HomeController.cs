using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using insuranceClaims.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace insuranceClaims.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;
        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet("newinventory/{room}")]
        public IActionResult ViewRoom(string room)
        {
            return View();
        }
        [HttpGet("/newinventory/{room}/{itemId}")]
        public IActionResult NewSubmissionForm (int itemId, string room)
        {
            ViewBag.OriginalId = _context.LostItems.FirstOrDefault(a=>a.ID == itemId);
            return View("NewInventorySubmission");
        }
        [HttpPost("/newInventorySubmission")]
        public IActionResult NewSubmission(NewInventory newItem)
        {   
            ViewBag.OriginalItem = _context.LostItems.FirstOrDefault(a=>a.ID == newItem.OriginalId);
            decimal PerItemDepreciation = ((ViewBag.OriginalItem.Depreciation)/ (ViewBag.OriginalItem.QuantityL));
            decimal ProdDifference = newItem.UnitPrice - ViewBag.OriginalItem.UnitPrice;
            decimal recoveredPerItem = Math.Min(PerItemDepreciation,ProdDifference);
            newItem.Recovered = recoveredPerItem;
            newItem.ReceiptName = (newItem.ProductName + (string)"receipt");
            if(ModelState.IsValid)
            {
                _context.ReplacedItems.Add(newItem);
                _context.SaveChanges();
                return RedirectToAction("dashboard");
            } else{
                // i need to pass the room back in for hidden form
                return View ("NewInventorySubmission");
            }
        }
        [HttpPost ("adduser")]
        public IActionResult AddUser(User newuser)
        {
            return RedirectToAction ("Dashboard");


||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||



// ADDiING NEW USERS. DB is IN! YOU'RE GONNA GET THIS DONE!



|||||||||||||||||||||||||||||||||||||||||||||||||||||||||




        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
