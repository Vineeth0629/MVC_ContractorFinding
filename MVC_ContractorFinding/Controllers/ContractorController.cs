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
 
        public ActionResult Details(int id)
        {
            IList<Contract> custlist = JsonConvert.DeserializeObject<IList<Contract>>((string)TempData["custList"]);
            TempData["custList"] = JsonConvert.SerializeObject(custlist);
            Contract cust = custlist.Where(cust => cust.ContractorId == id).FirstOrDefault();
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

                return RedirectToAction(nameof(ContractorView));
            }
            catch
            {
                return View();
            }
        }



        //GET: ContractorController/Edit/5
        public ActionResult Edit(int id)
        {
            IList<Contract> custList = JsonConvert.DeserializeObject<IList<Contract>>((string)TempData["custList"]);
            TempData["custList"] = JsonConvert.SerializeObject(custList);
            Contract cust = custList.Where(cust => cust.ContractorId == id).FirstOrDefault();
            return View(cust);

        }

        // POST: ContractorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Contract custMdl)
        {
            try
            {
                string token = TempData["token"].ToString();
                await _ids.updatecontractor(custMdl, token);
                TempData["token"] = token;
                return RedirectToAction(nameof(ContractorView));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            IList<Contract> custlist = JsonConvert.DeserializeObject<IList<Contract>>((string)TempData["custList"]);
            TempData["custList"] = JsonConvert.SerializeObject(custlist);
            Contract cust = custlist.Where(cust => cust.ContractorId == id).FirstOrDefault();
            return View(cust);

        }

        // POST: CustomerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int id, Contract custMdl)
        //{
        //    try
        //    {
        //        string token = TempData["token"].ToString();
        //        TempData["token"] = token;
        //        await _ids.deletecontractor(id.ToString(), token);

        //        return RedirectToAction(nameof(ContractorView));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        }
    }


