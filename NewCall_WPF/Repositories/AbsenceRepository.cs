using NewCall_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.Repositories
{
    public class AbsenceRepository : IAbsenceRepository
    {
        HttpClient client = new HttpClient();
        public async Task<bool> AddAbsence(Absences absence)
        {
            bool validAbsence;

            var reponse = await client.PostAsJsonAsync("http://localhost:5164/api/Absence/Create", absence);
            if (reponse.IsSuccessStatusCode)
            {
                validAbsence = true;
            }
            else
            {
                validAbsence = false;
            }
            return validAbsence;
        }
    }
}
