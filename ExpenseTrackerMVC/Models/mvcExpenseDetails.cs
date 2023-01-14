using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackerMVC.Models
{
    public class mvcExpenseDetails
    {
        public int expenseid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public System.DateTime date { get; set; }
        public int amount { get; set; }
        public int categoryid { get; set; }

        public virtual mvcCategories Category { get; set; }
    }
}