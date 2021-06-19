using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Commons.Attributes;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using MISA.CukCuk.Core.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    /// <summary>
    /// Service nhân viên xử lý logic 
    /// </summary>
    /// CreatedBy CMChau 16/6/2021
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
            if (employee.EntityState == Enum.EntityState.INSERT)
            {
                isValidCode = CheckValidateCode(employee.EmployeeCode, null);
            }
            else
            {
                isValidCode = CheckValidateCode(employee.EmployeeCode, employee.EmployeeId);
            }
            if (isValidCode == true)
                throw new ValidateException(Properties.EmployeeResource.Error_Duplicate_EmployeeCode, employee.EmployeeCode);

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
        /// Xuất khẩu danh sách nhân viên theo lọc ra file excel
        /// </summary>
        /// <param name="textFilter">Từ khóa lọc</param>
        /// <returns>Danh sách nhân viên theo lọc</returns>
        /// CreatedBy CMChau 16/6/2021
        public byte[] ExportAllData(string textFilter)
        {
            var employees = _baseRepository.GetAllFilter(textFilter);
            using (var workbook = new XLWorkbook())
            {

                // Định dạng row header
                var worksheet = workbook.Worksheets.Add(Properties.ExcelResource.File_EmployeeName);
                worksheet.Row(1).Height = 20;
                // Merge dòng
                var rangeHeader = worksheet.Range(1, 1, 1, 9).Merge();
                rangeHeader.Value = ExcelResource.Header_Title;
                rangeHeader.Style.Font.Bold = true;
                rangeHeader.Style.Font.FontSize = 16;
                rangeHeader.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                worksheet.Range(2, 1, 2, 9).Merge();
                // Định dạng row title
                var rangeTitle = worksheet.Range(3, 1, 3, 9);
                rangeTitle.Style.Font.Bold = true;
                rangeTitle.Style.Fill.BackgroundColor = XLColor.LightGray;
                rangeTitle.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                var currentRow = 3;
                // Tạo border cho cell
                for (int k = 1; k < 10; k++)
                {
                    worksheet.Cell(3, k).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
                int i = 1;
                // Tiêu đề
                worksheet.Cell(currentRow, i++).Value = ExcelResource.Title_Sort;
                worksheet.Cell(currentRow, i++).Value = ExcelResource.Title_EmployeeCode;
                worksheet.Cell(currentRow, i++).Value = ExcelResource.Title_Name;
                worksheet.Cell(currentRow, i++).Value = ExcelResource.Title_Gender;
                worksheet.Cell(currentRow, i++).Value = ExcelResource.Title_Dob;
                worksheet.Cell(currentRow, i++).Value = ExcelResource.Title_PositionName;
                worksheet.Cell(currentRow, i++).Value = ExcelResource.Title_DepartmentName;
                worksheet.Cell(currentRow, i++).Value = ExcelResource.Title_BankAccount;
                worksheet.Cell(currentRow, i++).Value = ExcelResource.Title_BankBranch;
                // Nội dung cell
                int j = 1;
                foreach (var employee in employees)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = j++; // todo chưa sort theo thứ tự trong db được
                    worksheet.Cell(currentRow, 2).Value = employee.EmployeeCode;
                    worksheet.Cell(currentRow, 3).Value = employee.FullName;
                    worksheet.Cell(currentRow, 4).Value = employee.GenderName;
                    worksheet.Cell(currentRow, 5).Value = employee.DateOfBirth;
                    worksheet.Cell(currentRow, 6).Value = employee.PositionName;
                    worksheet.Cell(currentRow, 7).Value = employee.DepartmentName;
                    worksheet.Cell(currentRow, 8).Value = employee.BankAccount; // Todo xuất ra file excel ko nhận string
                    worksheet.Cell(currentRow, 9).Value = employee.BankName;
                    for (int c = 1; c < 10; c++)
                    {
                        worksheet.Cell(currentRow, c).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }
                }
                // Căn khoảng cách trong 1 cột
                worksheet.Columns("A", "I").AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }



        public Employee GetDuplicateEmployee(Guid id)
        {
            var newCode = base.GetNewCode();
            var employee = _baseRepository.GetById(id);
            if (employee == null)
                return employee;
            else
            {
                employee.EmployeeCode = newCode;
                return employee;
            }
        }



        #endregion
    }
}
