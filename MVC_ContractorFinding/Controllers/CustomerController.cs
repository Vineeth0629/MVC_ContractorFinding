using CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace MVC_ContractorFinding.Controllers
{
    public class CustomerController : Controller
    {
        IDScustomer _ids;
        public CustomerController(IDScustomer ids)
        {
            _ids = ids;
        }
        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            try
            {
                string token = TempData["token"].ToString();

                IList<customer> custList = await _ids.GetCustomer(token);
                return View(custList);

                return RedirectToAction("ContractorView", "Contractor", new { area = "" });
            }
            catch
            {
                return View();
            }
    }
        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: CustomerController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(customer userMdl)
        //{
        //    try
        //    {
        //        string token = TempData["token"].ToString();
        //        List<customer> custList = await _ids.InsertCustomer(token);
        //        return View(custList);


        //        //  return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
