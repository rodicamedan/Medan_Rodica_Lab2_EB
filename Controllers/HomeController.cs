using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Medan_Rodica_Lab2_EB.Models;
using Microsoft.EntityFrameworkCore;
using Medan_Rodica_Lab2_EB.Data;
using Medan_Rodica_Lab2_EB.Models.LibraryViewModels;

namespace Medan_Rodica_Lab2_EB.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;
        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
                from order in _context.Orders
                group order by order.OrderDate into dateGroup
                select new OrderGroup()
                {
                    OrderDate = dateGroup.Key,
                    BookCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}