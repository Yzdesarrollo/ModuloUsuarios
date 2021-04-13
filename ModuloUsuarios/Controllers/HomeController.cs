using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModuloUsuarios.Models;
using ModuloUsuarios.Models.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloUsuarios.Controllers
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
            var autoService = new AutoServices();
            var auto = autoService.ObtenerAuto();

            return View(auto);
        }

        public IActionResult Privacy()
        {

            var autoServices = new AutoServices();

            return View(autoServices.ObtenerAutos());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
