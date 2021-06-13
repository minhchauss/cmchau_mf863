using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        #region Declare

        #endregion
        #region Methods
        /// <summary>
        /// Kiểm tra trùng số điện thoại
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <param name="employeeId">id nhân viên</param>
        /// <returns>True - bị trùng, False - không trùng</returns>
        public bool CheckEmployeePhoneNumber(string phoneNumber, Guid? employeeId);

        /// <summary>
        /// Kiểm tr trùng Số CMND/Căn Cước
        /// </summary>
        /// <param name="identityNo">Số CMND/Căn cước</param>
        /// <param name="employeeId">id nhân viên</param>
        /// <returns>True - bị trùng, False - không trùng</returns>
        public bool CheckEmployeeIdentityNo(string identityNo, Guid? employeeId);
        #endregion
    }
}
