using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Commons.Attributes;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (isValidIdentityNo == true)
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
        public bool CheckValidateIdentity(string identityNo, Guid? id)
        {
            var res = _employeeRepository.CheckEmployeeIdentityNo(identityNo, id);
            return res;
        }

        public byte[] ExportAllData()
        {
            var employees = _baseRepository.GetAll();
            using (var workbook = new XLWorkbook())
            {
               
                // Định dạng row header
                var worksheet = workbook.Worksheets.Add("Danh sách nhân viên");
                worksheet.Columns("A", "I").AdjustToContents();
                worksheet.Columns("A", "I").Style.Border.OutsideBorder=XLBorderStyleValues.Medium;
                var rangeHeader = worksheet.Range(1, 1, 1, 9).Merge();
                rangeHeader.Value = "DANH SÁCH NHÂN VIÊN";
                rangeHeader.Style.Font.Bold = true;
                rangeHeader.Style.Font.FontSize = 16;
                rangeHeader.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                worksheet.Range(2, 1, 2, 9).Merge();
                // Định dạng row title
                var rangeTitle = worksheet.Range(3, 1, 3, 9);
                rangeTitle.Style.Font.Bold = true;
                rangeTitle.Style.Fill.BackgroundColor = XLColor.Gray;
                var currentRow = 3;
                // Tiêu đề
                worksheet.Cell(currentRow, 1).Value = "STT";
                worksheet.Cell(currentRow, 2).Value = "Mã nhân viên";
                worksheet.Cell(currentRow, 3).Value = "Tên nhân viên";
                worksheet.Cell(currentRow, 4).Value = "Giới tính";
                worksheet.Cell(currentRow, 5).Value = "Ngày sinh";
                worksheet.Cell(currentRow, 6).Value = "Chức danh";
                worksheet.Cell(currentRow, 7).Value = "Tên đơn vị";
                worksheet.Cell(currentRow, 8).Value = "Số tài khoản";
                worksheet.Cell(currentRow, 9).Value = "Tên ngân hàng";
                foreach (var employee in employees)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = employee.Sort;
                    worksheet.Cell(currentRow, 2).Value = employee.EmployeeCode;
                    worksheet.Cell(currentRow, 3).Value = employee.FullName;
                    worksheet.Cell(currentRow, 4).Value = employee.GenderName;
                    worksheet.Cell(currentRow, 5).Value = employee.DateOfBirth;
                    worksheet.Cell(currentRow, 6).Value = employee.DepartmentName;
                    worksheet.Cell(currentRow, 7).Value = employee.PositionName;
                    worksheet.Cell(currentRow, 8).Value = employee.BankAccount;
                    worksheet.Cell(currentRow, 9).Value = employee.BankName;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return content;
                }
            }
        }
        #endregion
    }
}
