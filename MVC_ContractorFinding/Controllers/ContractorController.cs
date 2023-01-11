using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using CommonModels;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using Contract = ServiceLayer.Contract;

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
        public async Task<ActionResult> ContractorView()
        {
            string token = TempData["token"].ToString();
            IList<ContractorDisplay> custList = await _ids.GetContract(token);
            TempData["token"] = token;
            TempData["custList"] = JsonConvert.SerializeObject(custList);



            return View(custList);
        }

        // GET: ContractorController/Details/5

        public ActionResult Details(int id)
        {
            IList<ContractorDisplay> custlist = JsonConvert.DeserializeObject<IList<ContractorDisplay>>((string)TempData["custList"]);
            TempData["custList"] = JsonConvert.SerializeObject(custlist);
            IList<Contract> data = (from custLists in custlist
                                    select new Contract
                                    {
                                        ContractorId = custLists.ContractorId,
                                        Services = custLists.Services == null ? 0 : custLists.Services == "type1" ? 1 : 2,
                                        CompanyName = custLists.CompanyName,
                                        Gender = custLists.Gender == null ? 0 : custLists.Gender == "Male" ? 1 : custLists.Gender == "Femaile" ? 2 : 3,
                                        License = custLists.License,
                                        Lattitude = custLists.Lattitude,
                                        Longitude = custLists.Longitude,
                                        Pincode = custLists.Pincode,
                                        PhoneNumber = custLists.PhoneNumber,
                                        Contractor = custLists.Contractor,
                                        GenderNavigation = custLists.GenderNavigation,
                                        ServicesNavigation = custLists.ServicesNavigation,
                                    }).ToList();
            
            Contract cust = data.Where(cust => cust.ContractorId == id).FirstOrDefault();
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
        public async Task<IActionResult> Create(ContractorDetail userMdl)
        {
            try
            {

                string token = TempData["token"].ToString();
                TempData["token"] = token;
                // List<customer> custList =
                await _ids.CreateContractorDetail(userMdl, token);
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

            IList<ContractorDisplay> custList = JsonConvert.DeserializeObject<IList<ContractorDisplay>>((string)TempData["custList"]);
            IList<Contract> data=(from custLists in custList select new Contract
            {
                ContractorId= custLists.ContractorId,
                Services=custLists.Services == null? 0:  custLists.Services == "type1" ? 1 : 2,
                CompanyName=custLists.CompanyName,              
                Gender = custLists.Gender == null ? 0 : custLists.Gender == "Male"? 1 :custLists.Gender=="Femaile"? 2:3,
                License = custLists.License,
                Lattitude = custLists.Lattitude,
                Longitude = custLists.Longitude,
                Pincode=custLists.Pincode,
                PhoneNumber=custLists.PhoneNumber,
                Contractor=custLists.Contractor,
                GenderNavigation=custLists.GenderNavigation,
                ServicesNavigation=custLists.ServicesNavigation,
            }).ToList();
            TempData["custList"] = JsonConvert.SerializeObject(custList);
            Contract cust = data.Where(cust => cust.ContractorId == id).FirstOrDefault();
            return View(cust);

        }

        // POST: ContractorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ContractorDetail userMdl)
        {
            try
            {
                string token = TempData["token"].ToString();
                await _ids.updatecontractor(userMdl, token);
                TempData["token"] = token;
                return RedirectToAction(nameof(ContractorView));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(string id)
        {
            IList<ContractorDisplay> custlist = JsonConvert.DeserializeObject<IList<ContractorDisplay>>((string)TempData["custList"]);
            TempData["custList"] = JsonConvert.SerializeObject(custlist);
          //  ContractorDisplay cust = custlist.Where(cust => cust.License == id).FirstOrDefault();

            IList<Contract> data = (from custLists in custlist
                                    select new Contract
                                    {
                                        ContractorId = custLists.ContractorId,
                                        Services = custLists.Services == null ? 0 : custLists.Services == "type1" ? 1 : 2,
                                        CompanyName = custLists.CompanyName,
                                        Gender = custLists.Gender == null ? 0 : custLists.Gender == "Male" ? 1 : custLists.Gender == "Femaile" ? 2 : 3,
                    
                                        License = custLists.License,
                                        Lattitude = custLists.Lattitude,
                                        Longitude = custLists.Longitude,
                                        Pincode = custLists.Pincode,
                                        PhoneNumber = custLists.PhoneNumber,
                                        Contractor = custLists.Contractor,
                                        GenderNavigation = custLists.GenderNavigation,
                                        ServicesNavigation = custLists.ServicesNavigation,
                                    }).ToList();

            Contract cust = data.Where(cust => cust.License == id).FirstOrDefault();
            return View(cust);

        }



        //POST: CustomerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        public async Task<ActionResult> Delete(int id, ContractorDetail custMdl)
        {
            try
            {
                string token = TempData["token"].ToString();
                TempData["token"] = token;
                await _ids.deletecontractor(id.ToString(), token);

                return RedirectToAction(nameof(ContractorView));
            }
            catch
            {
                return View();
            }
        }
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
        //}
    }
}


