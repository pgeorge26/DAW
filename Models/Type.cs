﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amada_Management.Models
{
    public class Type
    {
        [Key]
        public int TypeId { get; set; }

        public string Name { get; set; }

        // many to many
        public virtual ICollection<Food> Foods { get; set; }
    }
}