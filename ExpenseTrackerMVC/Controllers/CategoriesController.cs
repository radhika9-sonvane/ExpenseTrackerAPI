using ExpenseTrackerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerMVC.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            IEnumerable<mvcCategories> categories;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
            categories = response.Content.ReadAsAsync<IEnumerable<mvcCategories>>().Result;
            return View(categories);
            
        }
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcCategories());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Categories/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCategories>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(mvcCategories c)
        {
            if (c.categoryid == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Categories", c).Result;
                TempData["SuccessMessage"] = "New Category inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Categories/" + c.categoryid, c).Result;
                TempData["SuccessMessage"] = "Category Updated Successfully";
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Categories/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
        
    }
}