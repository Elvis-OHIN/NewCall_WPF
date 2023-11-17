using NewCall_WPF.Models;
using NewCall_WPF.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.Repositories
{
    public class AdminRepository :  IAdminRepository
    {
        HttpClient client = new HttpClient();


        public async Task<bool> AuthenticateAdmin(NetworkCredential credential)
        {
            bool validAdmin;

            var reponse = await client.PostAsJsonAsync("http://localhost:5164/api/Admins/login", new AdminModel { Identifiant = credential.UserName , Password = credential.Password });
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
    }
}
