using NewCall_WPF.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            var reponse = await client.PostAsJsonAsync("http://localhost:5164/api/Absences/Create", absence);
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

        public async Task<List<Students>> GetAbsenceByDate(DateTime date)
        {
            List<Students> absence =  new List<Students>();
            try
            {
                DateTime parsedDate = DateTime.ParseExact(date.Date.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string formattedDate = parsedDate.ToString("yyyy-MM-dd");
                var reponse = await client.GetAsync($"http://localhost:5164/api/Absences/Date?date={formattedDate}");
                var content = await reponse.Content.ReadAsAsync<List<Students>>();
                return content;
            }
            catch {
                return absence;
            }
        }
    }
}
