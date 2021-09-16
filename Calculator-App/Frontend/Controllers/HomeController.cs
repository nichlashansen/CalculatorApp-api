using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpPost]
        public Task<string> GetResult(string input)
        {
            var arrayOfText= input.Split(" ");
            string a, b,option;
            a = arrayOfText[0];
            option = arrayOfText[1];
            b = arrayOfText[2];

            if (option == "+")
                option = "add";
            else if (option == "-")
                option = "minus";
            else if (option == "*")
                option = "multiply";
            else option = "divide";

            string result = $"/?a={a}&b={b}&option={option}";
            var client = new HttpClient();
            var httpResult =client.GetStringAsync("https://localhost:5001/api/Calculate" +result);
            return httpResult;


        }
    }
}