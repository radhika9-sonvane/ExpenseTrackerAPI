//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseTrackerAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExpenseDetail
    {
        public int expenseid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public System.DateTime date { get; set; }
        public int amount { get; set; }
        public int categoryid { get; set; }
    
        public virtual Category Category { get; set; }
    }
}