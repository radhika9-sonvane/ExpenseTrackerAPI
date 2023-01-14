using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseTrackerMVC.Models
{
    public class ExpenseClass
    {
        public int expenseid { get; set; }
       
        public string title { get; set; }
        
        public string description { get; set; }
        
        public System.DateTime date { get; set; }
        
        public int amount { get; set; }
        
        public string name { get; set; }
        public virtual mvcCategories Category { get; set; }
    }
}