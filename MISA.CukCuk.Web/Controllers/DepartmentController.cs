using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    /// <summary>
    /// Controller phòng ban
    /// </summary>
    /// CreatedBy CMChau 17/6/2021
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DepartmentController : BaseController<Department>
    {
        public DepartmentController(IBaseRepository<Department> baseRepository, IBaseService<Department> baseService):base(baseRepository, baseService)
        {

        }
    }
}
