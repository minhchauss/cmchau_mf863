using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository, ICustomerService customerService)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
        }
        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>
        /// 200 - Dữ liệu tất cả khách hàng
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception
        /// </returns>
        /// Created by CMChau (20/05/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerRepository.GetAll();
            if (customers.Count() > 0)
                return Ok(customers);
            return NoContent();
        }
        /// <summary>
        /// Lấy thông tin của 1 khách hàng
        /// </summary>
        /// <param name="id">Id khách hàng</param>
        /// <returns>
        /// 200 - Dữ liệu khách hàng
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception
        /// </returns>
        /// Created by CMChau (20/05/2021)
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Customer customer = _customerRepository.GetById(id);
            if (customer != null)
                return Ok(customer);
            return NoContent();
        }
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Dữ liệu khách hàng</param>
        /// <returns>
        /// 200 - Thêm mới thành công
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception
        /// </returns>
        /// Created by CMChau (20/05/2021)
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            customer.EntityState = Core.Enum.EntityState.Add;
            var rowAffect = _customerService.Insert(customer);
            if (rowAffect > 0)
                return Ok(rowAffect);
            return NoContent();
        }
        /// <summary>
        /// Sửa thông tin 1 khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <param name="id">id khách hàng</param>
        /// 200 - Sửa thành công
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception
        /// <returns>Số dòng đã sửa</returns>
        /// Created by CMChau (22/05/2021)
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Customer customer, Guid id)
        {
            int rowAffects = _customerService.Update(customer, id);
            if (rowAffects > 0)
                return Ok(rowAffects);
            return NoContent();
        }

        /// <summary>
        /// Xóa bản ghi của 1 khách hàng theo Id
        /// </summary>
        /// <param name="id">Id khách hàng</param>
        /// 200 - Xóa thành công
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception
        /// <returns>Số dòng đã xóa được</returns>
        /// Created by CMChâu 21/05/2021
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            int rowAffect = _customerRepository.DeleteById(id);
            if (rowAffect > 0)
                return Ok();
            return NoContent();

        }
    }
}
