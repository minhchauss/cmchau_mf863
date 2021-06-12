using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
   public class EmployeeService:BaseService<Employee>,IEmployeeService
    {
        #region Declare

        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository):base(employeeRepository)
        {

        }
        #endregion

        #region Methods

        #endregion
    }
}
