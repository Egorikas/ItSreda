using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Example6.WithOutDeadlock.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Block().Wait();
            return View();
        }

        public async Task Block()
        {
            await Task.Delay(300);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
