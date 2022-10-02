using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Data;
using OnionArchitecture.Service;
using System.Web.Http.Description;

namespace OnionArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("bs")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepo _departmentRepo;
        public DepartmentsController(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        /*****************************
        
           Department Related Action Start

        *****************************/

        [Route("GetDepartments")]
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _departmentRepo.GetDepartments();
            if (departments != null)
            {
                return Json(new { error = false, data = departments });
            }
            return Json(new { error = true, message = "Error! Departments data not found." });
        }

        [HttpGet]
        [Route("GetDepartment/{departmentId}")]
        public IActionResult GetDepartment(int departmentId)
        {
            var department = _departmentRepo.GetDepartment(departmentId);
            if (department!=null)
            {
                return Json(new { error = false, data= department });
            }
            return Json(new { error = true, message = "Error! Department data not found." });
        }

        [HttpPost]
        [Route("PostDepartment")]
        [ResponseType(typeof(JsonResult))]
        public IActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { error = true, message = "Please give the information properly." });
            }
            int rowAffected = _departmentRepo.AddDepartment(department);
            if (rowAffected>0)
            {
                return Json(new { error = false, message = "Department saved successfully." });
            }
            return Json(new { error = true, message = "Department is not saved. Please try again later." });
        }

        [HttpPut]
        [Route("PutDepartment")]
        [ResponseType(typeof(JsonResult))]
        public IActionResult PutDepartment(Department department)
        {
            if (department.Id <= 0)
            {
                return Json(new { error = true, message = "Error! Invalid request detected." });
            }
            if (!ModelState.IsValid)
            {
                return Json(new { error = true, message = "Please give the information properly." });
            }

            int rowAffected = _departmentRepo.EditDepartment(department);
            if (rowAffected > 0)
            {
                return Json(new { error = false, message = "Department updated successfully." });
            }
            else if (rowAffected == 0)
            {
                return Json(new { error = true, message = "Department is not updated. You did not change anything." });
            }
            else if (rowAffected == -3)
            {
                return Json(new { error = true, message = "Invalid request detected! Department is not updated." });
            }
            return Json(new { error = true, message = "Oops! Department updation failed. Please try again later." });
        }

        [HttpDelete]
        [Route("DeleteDepartment/{departmentId}")]
        [ResponseType(typeof(JsonResult))]
        public IActionResult DeleteDepartment(int? departmentId)
        {
            if (departmentId == null || departmentId <= 0)
            {
                return Json(new { error = true, message = "Error! Invalid request detected." });
            }
            int rowAffected = _departmentRepo.DeleteDepartment(departmentId.Value);
            if (rowAffected > 0)
            {
                return Json(new { error = false, message = "Department deleted successfully." });
            }
            else if (rowAffected == -3)
            {
                return Json(new { error = true, message = "Invalid request detected! Department is not deleted." });
            }
            return Json(new { error = true, message = "Oops! Department deletion failed. Please try again later." });
        }

        /*****************************
        
           Department Related Action End

        *****************************/
    }
}
