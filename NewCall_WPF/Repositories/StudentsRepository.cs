using NewCall_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using System.Text.Json;
using System.Net.Http.Json;

namespace NewCall_WPF.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        HttpClient client = new HttpClient();

        public async Task<bool> AddStudent(Students student)
        {
                bool validAdmin;
                using StringContent jsonContent = new(
               JsonSerializer.Serialize(new
               {
                   id = 0,
                   firstname = student.firstname,
                   lastname = student.lastname,
                   statut = student.statut,
               }),
               Encoding.UTF8,
               "application/json");

            var reponse = await client.PostAsync("http://localhost:5164/api/Students/Create", jsonContent);
            var jsonResponse = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
                {
                    validAdmin = true;
                }
                else
                {
                    validAdmin = false;
                }
                return validAdmin;
        }

        public async Task<List<Students>> GetAllStudent()
        {
            List<Students> students = new List<Students>();
            try
            {
                var reponse = await client.GetAsync($"http://localhost:5164/api/Students/Index");
                var content = await reponse.Content.ReadAsAsync<List<Students>>();
                return content;
            }
            catch
            {
                return students;
            }
        }
    }
}
