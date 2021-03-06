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
    /// <summary>
    /// Controller của khách hàng
    /// </summary>
    /// CreatedBy CMChau 17/6/2021
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {

        #region Declare
        public CustomerController(ICustomerRepository customerRepository, ICustomerService customerService):base(customerRepository,customerService)
        {
           
        }
        #endregion
      
    }
}
