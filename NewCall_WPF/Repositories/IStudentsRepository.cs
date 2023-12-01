using NewCall_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.Repositories
{
    public interface IStudentsRepository
    {
        Task<bool> AddStudent(Students student);

        Task<List<Students>> GetAllStudent();
    }
}
