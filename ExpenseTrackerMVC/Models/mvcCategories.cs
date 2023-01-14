using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackerMVC.Models
{
    public class mvcCategories
    {
        public int categoryid { get; set; }
        public string name { get; set; }
        public int expenselimit { get; set; }
        public virtual ICollection<mvcExpenseDetails> ExpenseDetails { get; set; }
    }
}