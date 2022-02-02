using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProcessing _processing;

        public HomeController(ILogger<HomeController> logger, IProcessing processing)
        {
            _logger = logger;
            _processing = processing;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Count(TextViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            model.ListWords = _processing.FindWordsRepeated(model.Text);

            return View("Result", model);
        }

        [HttpPost]
        public IActionResult Result(TextViewModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
