using OnionArchitecture.Data;
using OnionArchitecture.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Service
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private IRepository<Department> _repository;
        public DepartmentRepo(IRepository<Department> DepartmentRepo)
        {
            _repository = DepartmentRepo;
        }


        public IEnumerable<Department> GetDepartments()
        {
            return _repository.GetAll();
        }

        public Department GetDepartment(int id)
        {
            return _repository.Get(id);
        }
        public int AddDepartment(Department department)
        {
            return _repository.Insert(department);
        }
        public int EditDepartment(Department department)
        {
            return _repository.Update(department);
        }
        public int DeleteDepartment(int departmentId)
        {
            return _repository.Delete(departmentId);
        }
    }
}
