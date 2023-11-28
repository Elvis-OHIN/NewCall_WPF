using NewCall_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.Repositories
{
    public interface IAbsenceRepository
    {
        Task<bool> AddAbsence(Absences absence);
    }
}
