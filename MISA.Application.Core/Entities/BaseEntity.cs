using MISA.CukCuk.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Entity dùng chung
    /// </summary>
    /// Created by CMChau 19/05/2021
    public class BaseEntity
    {

        #region Properties

        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        /// Created by CMChau 19/05/2021
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string Createdby { get; set; }

        /// <summary>
        /// Người sửa đổi
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        /// Created by CMChau 19/05/2021
        public DateTime ModifiedDate { get; set; }


        public EntityState EntityState { get; set; } = EntityState.Add;
        #endregion
    }
}
