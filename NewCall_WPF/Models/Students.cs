using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.Models
{
    public class Students
    {
        public int id { get; set; }
        public string firstname { get; set; }

        public string lastname { get; set; }

        public string statut { get; set; }

        public ICollection<Absences>? Absences { get; set; }
        public Students(int id, string firstname, string lastname, string statut)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.statut = statut;
        }
    }
}
