using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Danh mục vị trí
    /// </summary>
    /// CreatedBy CMChau 11/6/2021
    public class Position
    {
        #region Properties

        /// <summary>
        /// Id vị trí
        /// </summary>
        /// CreatedBy CMChau 11/6/2021
        public Guid PositionId { get; set; }

        /// <summary>
        /// Tên vị trí làm việc
        /// </summary>
        /// CreatedBy CMChau 11/6/2021
        public string PositionName { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// CreatedBy CMChau 11/6/2021
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        /// CreatedBy CMChau 11/6/2021
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        /// CreatedBy CMChau 11/6/2021
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa đổi
        /// </summary>
        /// CreatedBy CMChau 11/6/2021
        public string ModifiedBy { get; set; }

        #endregion
    }
}
