using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        #region Declare
        List<Employee> employees = new List<Employee>();
        IBaseRepository<Employee> _baseRepository;
        IBaseService<Employee> _baseService;
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService,IEmployeeRepository employeeRepository, IBaseRepository<Employee> baseRepository) :base(employeeRepository,employeeService)
        {
            _baseRepository = baseRepository;
            _employeeService = employeeService;
        }
        #endregion

        [HttpPost("export")]
        public ActionResult WriteDataToExcel()
        {
            var result = _employeeService.ExportAllData();
            return File(result,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "users.xlsx");
        }
    }
}
