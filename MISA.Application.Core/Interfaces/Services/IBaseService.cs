using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Services
{
    public interface IBaseService<MSEntity>
    {
        #region Methods

        /// <summary>
        /// Cập nhật thông tin của 1 bản ghi
        /// </summary>
        /// <param name="entity">Thông tin của bản ghi</param>
        /// <param name="entityid">Id của bản ghi cần sửa</param>
        /// <returns>Số dòng đã update trong database</returns>
        /// Created by CMChau (19/05/2021)
      public  int Update(MSEntity entity, Guid entityid);

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">thông tin của 1 bản ghi</param>
        /// <returns>Số dòng đã thêm được vào database</returns>
        /// Created by CMChau (19/05/2021)
        public int Insert(MSEntity entity);

        /// <summary>
        /// Lấy mã mới nhất
        /// </summary>
        /// <returns>Mã mới nhất</returns>
        /// CreatedBy CMChau 12/06/2021
        public string GetNewCode();
       

        #endregion
    }
}
