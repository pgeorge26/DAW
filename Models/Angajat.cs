using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Amada_Management.Models
{
    public class Angajat
    {
        [MaxLength(256)]
        public string Nume { get; set; }

        [MaxLength(256)]
        public string Prenume { get; set; }
        public int Salariu { get; set; }

        [MaxLength(256)]
        public string Job { get; set; }

    }
    
}
           
   