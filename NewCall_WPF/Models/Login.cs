using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.Models
{
    class Login
    {
        public required string identifiant { get; set; }

        public required string password { get; set; }
    }
}
