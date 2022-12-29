using Microsoft.AspNetCore.Mvc;
using MVC_ContractorFinding.Models;
using System.Diagnostics;
using ServiceLayer;
namespace MVC_ContractorFinding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDSLogin dSLogin;

        public HomeController(ILogger<HomeController> logger, IDSLogin dSLogin)
        {
            _logger = logger;
            this.dSLogin = dSLogin;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: ContracterFindingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContracterFindingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                TbUser tbUser = new TbUser()
                {
                    emailId = collection["emailId"].ToString(),
                    password = collection["password"].ToString()

                };
                dSLogin.ValidateUser(tbUser);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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