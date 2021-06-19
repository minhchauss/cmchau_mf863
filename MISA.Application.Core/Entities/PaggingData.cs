using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Đối tượng chứ thông tin tổng số bản ghi và danh sách bản ghi
    /// </summary>
    /// <typeparam name="MSEntity">Kiểu đối tượng</typeparam>
    /// CreatedBy CMChau 16/6/2021
   public class PaggingData<MSEntity>
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        /// CreatedBy CMChau 16/6/2021
        public int TotalCount { get; set; }

        /// <summary>
        /// Danh sách bản ghi
        /// </summary>
        /// CreatedBy CMChau 16/6/2021
        public IEnumerable<MSEntity> Items { set; get; }
    }
}
