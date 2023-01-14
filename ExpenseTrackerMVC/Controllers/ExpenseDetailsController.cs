using ExpenseTrackerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerMVC.Controllers
{
    public class ExpenseDetailsController : Controller
    {
        // GET: ExpenseDetails
        public ActionResult Index()
        {
            IEnumerable<mvcCategories> catlist;
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
            catlist = responses.Content.ReadAsAsync<IEnumerable<mvcCategories>>().Result;
            ViewBag.category = catlist;

            IEnumerable<ExpenseClass> expenseDetails;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ExpenseDetails").Result;
            expenseDetails = response.Content.ReadAsAsync<IEnumerable<ExpenseClass>>().Result;
            return View(expenseDetails);
        }
        public ActionResult AddorEdit(int id = 0)
        {
            IEnumerable<mvcCategories> catlist;
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
            catlist = responses.Content.ReadAsAsync<IEnumerable<mvcCategories>>().Result;
            ViewBag.category = catlist;
            if (id == 0)
                return View(new mvcExpenseDetails());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ExpenseDetails/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcExpenseDetails>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(mvcExpenseDetails e)
        {
            IEnumerable<mvcCategories> catlist;
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
            catlist = responses.Content.ReadAsAsync<IEnumerable<mvcCategories>>().Result;

            if (e.expenseid == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("ExpenseDetails", e).Result;
                TempData["SuccessMessage"] = "New Expense inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("ExpenseDetails/" + e.expenseid, e).Result;
                TempData["SuccessMessage"] = "Expense Updated Successfully";
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("ExpenseDetails/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Expense Deleted Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult dashboard()
        {
            IEnumerable<mvcCategories> catlist;
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
            catlist = responses.Content.ReadAsAsync<IEnumerable<mvcCategories>>().Result;
            ViewBag.category = catlist;

            IEnumerable<dashboard> expenseDetails;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ExpenseDetails").Result;
            expenseDetails = response.Content.ReadAsAsync<IEnumerable<dashboard>>().Result;
            return View(expenseDetails);
        }
    }
}