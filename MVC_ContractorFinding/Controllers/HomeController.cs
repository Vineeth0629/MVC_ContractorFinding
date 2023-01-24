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
        private IDSRegistration dSRegistration;

        public HomeController(ILogger<HomeController> logger, IDSLogin dSLogin, IDSRegistration dSRegistration)
        {
            _logger = logger;
            this.dSLogin = dSLogin;
            this.dSRegistration = dSRegistration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<bool> Register(IFormCollection collection)
        {
            try
            {
                Registration registration = new Registration()
                {
                    emailId = collection["emailId"].ToString(),
                    password = collection["password"].ToString(),
                    firstName = collection["firstname"].ToString(),
                    lastName  = collection["lastName"].ToString(),
                    confirmationPassword = collection["confirmationPassword"].ToString(),
                    phoneNumber = Convert.ToInt64 ( collection["phoneNumber"]),
                    typeUser =Convert.ToInt32( collection["typeUser"]),
                    active = Convert.ToBoolean( collection["active"])
                };
                 bool isSuccess= dSRegistration.Registrations(registration).Result;

                // dSLogin.Logins();
                return View("Index");
               // return RedirectToAction("ShowDetails");
                //return RedirectToAction("Index","Customer",new {area=""});
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Forgetpassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<bool> Forgetpassword(IFormCollection collection)
        {
            try
            {
                Registration forgetpass = new Registration()
                {
                    emailId = collection["emailId"].ToString(),
                    password = collection["password"].ToString(),
                    confirmationPassword = collection["confirmationPassword"]
                };
                bool isSuccess = dSLogin.Forgetpassword(forgetpass).Result;

                // dSLogin.Logins();
                return View("Index");
                // return RedirectToAction("ShowDetails");
                //return RedirectToAction("Index","Customer",new {area=""});
            }
            catch
            {
                return View();
            }
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
                 string token=dSLogin.ValidateUser(tbUser).Result;
                TempData["token"] = token;
                // dSLogin.Logins();

                return RedirectToAction("ShowDetails");
              //return RedirectToAction("Index","Customer",new {area=""});
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ShowDetails()
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}