using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewCall_WPF.Models;

namespace NewCall_WPF.Repositories
{
    public interface IAdminRepository
    {
        Task<bool> AuthenticateAdmin(NetworkCredential credential);
    }
}
