using CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using ServiceLayer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
                TempData["token"]=token;
                TempData["custList"]= JsonConvert.SerializeObject(custList);
                return View(custList);

               // return RedirectToAction("ContractorView", "Contractor", new { area = "" });
            }
            catch
            {
                return View();
            }
    }
        // GET: CustomerController/Details/5
        public ActionResult Details(string id)
        {
            IList<customer> custlist = JsonConvert.DeserializeObject<IList<customer>>((string)TempData["custList"] );
            TempData["custList"] = JsonConvert.SerializeObject(custlist);
            customer cust = custlist.Where(cust => cust.RegistrationNo == id).FirstOrDefault();
            return View(cust);
        }


        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(customer userMdl)
        {
            try
            {
                string token = TempData["token"].ToString();
                TempData["token"] =token;
                // List<customer> custList =
                await _ids.InsertCustomer(userMdl, token);
                //return View(custList);


                 return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(string id)
        {
            IList<customer> custList = JsonConvert.DeserializeObject<IList<customer>>((string)TempData["custList"]);
            TempData["custList"] = JsonConvert.SerializeObject(custList);
            customer cust = custList.Where(cust => cust.RegistrationNo == id).FirstOrDefault();
            return View(cust);
           
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, customer custMdl)
        {
            try
            {
                string token = TempData["token"].ToString();
                await _ids.UpdateCustomer(custMdl, token);
                TempData["token"]=token;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(string id)
        {
            IList<customer> custlist = JsonConvert.DeserializeObject<IList<customer>>((string)TempData["custList"]);
            TempData["custList"] = JsonConvert.SerializeObject(custlist);
            customer cust = custlist.Where(cust => cust.RegistrationNo == id).FirstOrDefault();
            return View(cust);
            
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, customer custMdl)
        {
            try
            {
                string token = TempData["token"].ToString();
                TempData["token"] = token;
                await _ids.deleteCustomer(id.ToString(), token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
