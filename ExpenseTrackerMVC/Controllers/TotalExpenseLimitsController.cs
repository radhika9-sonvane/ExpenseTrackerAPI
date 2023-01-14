using ExpenseTrackerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerMVC.Controllers
{
    public class TotalExpenseLimitsController : Controller
    {
        // GET: TotalExpenseLimits
        public ActionResult Index()
        {
            IEnumerable<mvcTotalExpenseLimits> limit;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TotalExpenseLimits").Result;
            limit=response.Content.ReadAsAsync<IEnumerable<mvcTotalExpenseLimits>>().Result;
            return View(limit);
        }
        public ActionResult AddorEdit(int id=0)
        {
            if(id==0)
                return View(new mvcTotalExpenseLimits());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TotalExpenseLimits/"+ id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcTotalExpenseLimits>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(mvcTotalExpenseLimits e)
        {
            if(e.totalexpenseid==0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("TotalExpenseLimits", e).Result;
                TempData["SuccessMessage"] = "New Limit inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("TotalExpenseLimits/"+ e.totalexpenseid,e).Result;
                TempData["SuccessMessage"] = "Limit Updated Successfully";
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("TotalExpenseLimits/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}