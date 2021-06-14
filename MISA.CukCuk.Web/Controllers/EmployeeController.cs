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

        /// <summary>
        /// Xuất khẩu ra file excel
        /// </summary>
        /// <returns>File excel chứa thông tin nhân viên</returns>
        [HttpGet("export")]
        public IActionResult WriteDataToExcel(string textFilter)
        {
            var result = _employeeService.ExportAllData(textFilter);
            return File(result,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Danh sách nhân viên.xlsx");
        }


        /// <summary>
        /// Lấy ra thông tin nhân bản của nhân viên
        /// </summary>
        /// <param name="id">id của nhân viên nhân bản</param>
        /// <returns>Thông tin nhân bản của nhân viên</returns>
        /// CreatedBy CMChau 14/6/2021
        [HttpGet("duplicate/{id}")]
        public IActionResult GetDuplicateEmp(Guid id)
        {
            var res = _employeeService.GetDuplicateEmployee(id);
            if (res != null)
                return Ok(res);
            else
                return NoContent();
        }
    }
}
