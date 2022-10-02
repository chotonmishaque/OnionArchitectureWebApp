using OnionArchitecture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Service
{
    public interface IDepartmentRepo
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int id);
        int AddDepartment(Department department);
        int EditDepartment(Department department);
        int DeleteDepartment(int departmentId);
    }
}
