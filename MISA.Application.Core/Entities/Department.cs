using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin phòng ban
    /// </summary>
    /// Created by CMChau 11/06/2021
    public class Department:BaseEntity
    {
        #region Properties

        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// Created by CMChau 11/06/2021
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// Created by CMChau 11/06/2021
        public string DepartmentName { get; set; }
        #endregion
    }
}
