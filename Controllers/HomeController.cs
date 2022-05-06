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
        [HttpGet ("AllInventory")]
        public IActionResult AllInventory()
        {
            // List of all lost items
            ViewBag.ViewAll = _context.LostItems
                .OrderBy(a=>a.OldProduct)
                .ToList();
            //List of all replaced items
            ViewBag.ViewNew = _context.ReplacedItems
                .OrderBy(a=>a.ProductName).ToList();
            //List of rooms for page selection
            ViewBag.AllRooms = _context.LostItems
                .Select(a=>a.Room)
                .Distinct();
            return View();
        }
        [HttpGet("ViewRoom/{room}")]
        public IActionResult ViewRoom(string room)
        {
            //List of all lost items in a given room. 
            //Need to refine to not list items repurchased. 
            ViewBag.OneRoom = _context.LostItems
                .Where(a=>a.Room == room)
                .OrderBy(a=>a.OldProduct)
                .ToList();
            ViewBag.AllRooms = _context.LostItems
                .Select(a=>a.Room)
                .Distinct();
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
        public IActionResult AddUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(a=> a.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Dashboard");
            } else{
                return View("Index");
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LogUser logUser)
        {
            if(ModelState.IsValid)
            {
                User userInDB = _context.Users.FirstOrDefault(a=> a.Email == logUser.LogEmail);
                if(userInDB == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid login credentials");
                    return View ("Index");
                }
                var hasher = new PasswordHasher<LogUser>();
                var result = hasher.VerifyHashedPassword(logUser, userInDB.Password, logUser.LogPassword);
                if(result ==0)
                {
                    ModelState.AddModelError("LogEmail", "Invalid login credentials");
                    return View ("Index");
                }
                HttpContext.Session.SetInt32("UserId", userInDB.UserId);
                return RedirectToAction("Dashboard");
            } else{
                return View("Index");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
