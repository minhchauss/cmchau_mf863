using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Enum
{
    /// <summary>
    /// Trạng thái của object
    /// </summary>
    /// Created by CMChau 22/05/2021
    /// <summary>
    /// Kiểu phương thức 
    /// </summary>
    public enum EntityState
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        GET,

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        INSERT,

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        UPDATE,

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        DELETE
    }

    /// <summary>
    /// Giới tính
    /// </summary>
    /// Created by CMChau 22/05/2021
    public enum Gender
    {
        /// <summary>
        /// Nam
        /// </summary>
        Male =0,
        /// <summary>
        /// Nữ
        /// </summary>
        Female = 1,
        /// <summary>
        /// Khác
        /// </summary>
        Other = 2
    }
}
