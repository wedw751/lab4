using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Infrastructures;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
            private readonly ILogger<HomeController> _logger;

            private DataManager _dataManager;
            private ServiceManager _serviceManage;


            public HomeController(ILogger<HomeController> logger, DataManager dataManager)
            {
                _logger = logger;
                _dataManager = dataManager;
                _serviceManage = new ServiceManager(_dataManager);
            }

        public IActionResult Index()
        {
            ViewBag.Preparation = _dataManager.Preparations.GetAll();
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
