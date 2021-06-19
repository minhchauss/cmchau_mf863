using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Services
{
    /// <summary>
    /// Service nhân viên
    /// </summary>
    /// CreatedBy CMChau 16/6/2021
    public interface IEmployeeService : IBaseService<Employee>
    {
        #region Declare

        #endregion
        #region Methods
        /// <summary>
        /// Xuất khẩu dữ liệu theo lọc
        /// </summary>
        /// <param name="textFilter">Từ khóa lọc</param>
        /// <returns>Dữ liệu để xuất khẩu</returns>
        /// CreatedBy CMChau 14/6/2021
        public byte[] ExportAllData(string textFilter);

        /// <summary>
        /// Lấy ra 1 nhân viên được nhân bản
        /// </summary>
        /// <param name="id">id của nhân viên nhân bản</param>
        /// <returns>Thông tin nhân viên đó với mã mới</returns>
        /// CreatedBy CMChau 14/6/2021
        public Employee GetDuplicateEmployee(Guid id);
        #endregion
    }
}
