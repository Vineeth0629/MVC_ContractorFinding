using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using CommonModels;
using Newtonsoft.Json;

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
            TempData["token"] = token;
            TempData["custList"] = JsonConvert.SerializeObject(custList);



            return View(custList);
        }

        // GET: ContractorController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        public ActionResult Details(string id)
        {
            IList<customer> custlist = JsonConvert.DeserializeObject<IList<customer>>((string)TempData["custList"]);
            TempData["custList"] = JsonConvert.SerializeObject(custlist);
            customer cust = custlist.Where(cust => cust.RegistrationNo == id).FirstOrDefault();
            return View(cust);
        }
        // GET: ContractorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Contract userMdl)
        {
            try
            {

                string token = TempData["token"].ToString();
                TempData["token"] = token;
                // List<customer> custList =
                await _ids.InsertContractor(userMdl, token);
                //return View(custList);

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
