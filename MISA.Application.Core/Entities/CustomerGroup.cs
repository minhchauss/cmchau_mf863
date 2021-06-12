using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin nhóm khách hàng
    /// </summary>
    /// Created by CMChau (19/05/2021)
    public class CustomerGroup
    {
        #region Properties

        /// <summary>
        /// Khóa chính
        /// </summary>
        /// Created by CMChau (19/05/2021)
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        /// Created by CMChau (19/05/2021)
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        /// Created by CMChau (19/05/2021)
        public string Description { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// Created by CMChau (19/05/2021)
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        /// Created by CMChau (19/05/2021)
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày thay đổi
        /// </summary>
        /// Created by CMChau (19/05/2021)
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người thay đổi
        /// </summary>
        /// Created by CMChau (19/05/2021)
        public string ModifiedBy { get; set; }
        #endregion
    }
}
