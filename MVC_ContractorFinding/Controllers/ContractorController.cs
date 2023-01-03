using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using CommonModels;
namespace MVC_ContractorFinding.Controllers
{
    public class ContractorController : Controller
    {
        IDsContract _ids;
        public ContractorController(IDsContract ids)
        {
            _ids = ids;

        }
        // GET: ContractorController
        public async Task <ActionResult> ContractorView()
        {
            string token = TempData["token"].ToString();
            IList<Contract> custList = await _ids.GetContract(token);

            return View(custList);
        }

        // GET: ContractorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContractorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ContractorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContractorController/Edit/5
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

        // GET: ContractorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContractorController/Delete/5
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
