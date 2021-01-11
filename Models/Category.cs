using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amada_Management.Models
{
    public class Category
    {
       //EF marcheaza proprietatea CategoryId ca fiind o cheie primara by default deorece respecta "naming convention" 
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // many to many
        public virtual ICollection<Food> Foods { get; set; }
    }
}