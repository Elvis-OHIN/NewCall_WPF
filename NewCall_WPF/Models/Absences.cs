using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.Models
{
    public class Absences
    {
        public int id { get; set; }

        public int studentId { get; set; }

        public DateTime startDate { get; set; }

        public DateTime? endDate { get; set; }

        public string? reason { get; set; }

        public string? comments { get; set; }
    }
}
