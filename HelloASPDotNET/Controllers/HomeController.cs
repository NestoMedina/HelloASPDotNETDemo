using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloASPDotNET.Models;

namespace HelloASPDotNET.Controllers
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

        public IActionResult CreateMessage(string name, string language)
        {
            List<string> greetings = new List<string>
            {
                $"<h1 style='color:red;'>Hello, {name}</h1>",
                $"<h1 style='color:red;'>Hola, {name}</h1>",
                $"<h1 style='color:red;'>Merhaba, {name}</h1>",
                $"<h1 style='color:red;'>Kamusta, {name}</h1>",
                $"<h1 style='color:red;'>Hallo, {name}</h1>"
            };
            string html = "";
            if (language.ToLower() == "english")
            {
                html = greetings[0];
            }
            else if (language.ToLower() == "spanish")
            {
                html = greetings[1];
            }
            else if (language.ToLower() == "turkish")
            {
                html = greetings[2];
            }
            else if (language.ToLower() == "filipino")
            {
                html = greetings[3];
            }
            else if (language.ToLower() == "german")
            {
                html = greetings[4];
            }

            return Content(html, "text/html");
        }

        public IActionResult Form()
        {
            string openForm = "<form method='get' action='/Home/CreateMessage/'>";
            string closedForm = "</form>";
            string selectOpen = "<select name='language'>";
            string selectClosed = "</select>";
            string selectOptionClosed = "</option>";
            string inputField = "<input type='text' name='name'/>";

            string html = $"{openForm} {inputField} {selectOpen} " +
                $"<option value='English'>English{selectOptionClosed} " +
                $"<option value='Spanish'>Spanish{selectOptionClosed} " +
                $"<option value='Turkish'>Turkish{selectOptionClosed} " +
                $"<option value='Filipino'>Filipino{selectOptionClosed}" +
                $"<option value='German'>German{selectOptionClosed}" +
                $"{selectClosed}" +
                $"<input type='submit' value='Greet Me!'>{closedForm}";

            return Content(html, "text/html");

        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
