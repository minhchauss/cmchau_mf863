using MISA.CukCuk.Core.Commons.Attributes;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declare
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Kiểm tra trùng dữ liệu nhập vào
        /// </summary>
        /// <param name="employee">Dữ liệu gửi lên từ client</param>
        /// CreatedBy CMChau 12/6/2021
        protected override void CheckValidateData(Employee employee)
        {
            var isValidCode = false;
            var isValidPhone = false;
            var isValidIdentityNo = false;
            if (employee.EntityState == Enum.EntityState.INSERT)
            {
                isValidCode = CheckValidateCode(employee.EmployeeCode, null);
                isValidPhone = CheckValidatePhoneNumber(employee.PhoneNumber, null);
                isValidIdentityNo = CheckValidateIdentity(employee.IdentityNo, null);
            }

            else
            {
                isValidCode = CheckValidateCode(employee.EmployeeCode, employee.EmployeeId);
                isValidPhone = CheckValidatePhoneNumber(employee.PhoneNumber, employee.EmployeeId);
                isValidIdentityNo = CheckValidateIdentity(employee.IdentityNo, employee.EmployeeId);
            }
            if (isValidCode == true)
                throw new ValidateException(Properties.EmplyeeResource.Error_Duplicate_EmployeeCode, employee.EmployeeCode);
            if (isValidPhone == true)
                throw new ValidateException(Properties.EmplyeeResource.Error_PhoneNumber_Exist, employee.PhoneNumber);
            if(isValidIdentityNo==true)
                throw new ValidateException(Properties.EmplyeeResource.Error_IdentityNo_Exist, employee.IdentityNo);
            base.CheckValidateData(employee);
        }


        /// <summary>
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// <returns>True - trùng mã , false - không trùng</returns>
        /// CreatedBy CMChau 13/6/2021
        public bool CheckValidateCode(string employeeCode, Guid? id)
        {
            var res = _baseRepository.CheckCodeExist(employeeCode, id);
            return res;
        }

        /// <summary>
        /// Kiêm tra trùng số điện thoại
        /// </summary>
        /// <param name="phoneNumber">số điện thoại</param>
        /// <param name="id">id nhân viên</param>
        /// <returns>True - bị trùng, False - không trùng</returns>
        /// CreatedBy CMChau 13/6/2021
        public bool CheckValidatePhoneNumber(string phoneNumber, Guid? id)
        {
            var res = _employeeRepository.CheckEmployeePhoneNumber(phoneNumber, id);
            return res;
        }

        /// <summary>
        /// Kiểm tra trùng số CMND/Căn cước
        /// </summary>
        /// <param name="identityNo">Số CMND/Căn cước</param>
        /// <param name="id">id nhân viên</param>
        /// <returns>True - bị trùng , False - không trùng</returns>
        /// CreatedBy CMChau 13/6/2021
        public bool CheckValidateIdentity(string identityNo,Guid? id)
        {
            var res = _employeeRepository.CheckEmployeeIdentityNo(identityNo, id);
            return res;
        }
        #endregion
    }
}
