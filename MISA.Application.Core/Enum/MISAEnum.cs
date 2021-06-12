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
    public enum EntityState
    {
        /// <summary>
        /// Thêm mới
        /// </summary>
        Add=1,
        /// <summary>
        /// Thêm mới
        /// </summary>
        Update=2,
        /// <summary>
        /// Xóa
        /// </summary>
        Delete=3
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
