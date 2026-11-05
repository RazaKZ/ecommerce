using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application;
using QST.ECommerce.Application.Contracts;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly ICatalogService _departmentService;
        // Constructor Injection - means it will inject the Object (in the parameters deptSvc = new DepartmentService();
        public DepartmentController(ICatalogService deptSvc)
        {
            _departmentService = deptSvc;
        }

        [HttpPost]
        public ActionResult AddDepartment(Department dept)
        {
            _departmentService.ManageDepartment(dept, Domain.Enums.DBCommands.Insert);
            return Ok("Department Saved Successfully");
        }

        [HttpGet("GetAllDepartments")]
        public ActionResult GetAllDepartments()
        {
            var list = _departmentService.GetAllDepartments();
            return Ok(list);
        }


    }
}
