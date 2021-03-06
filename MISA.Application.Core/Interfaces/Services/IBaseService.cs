using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Services
{
    /// <summary>
    /// Service dùng chung
    /// </summary>
    /// <typeparam name="MSEntity"></typeparam>
    /// CreatedBy CMChau 16/6/2021
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

        /// <summary>
        /// Lấy danh sách theo phân trang
        /// </summary>
        /// <param name="pageIndex">Trang số</param>
        /// <param name="pageSize">Số bản ghi/trang</param>
        /// <param name="textFilter">Từ khóa lọc</param>
        /// <returns>Danh sách theo phân trang</returns>
        /// CreatedBy CMChau 19/05/2021
        public PaggingData<MSEntity> GetPagingFilter(int pageIndex, int pageSize, string textFilter);



        /// <summary>
        /// Lấy toàn bộ danh sách theo lọc
        /// </summary>
        /// <param name="textFilter">Từ khóa lọc</param>
        /// <returns>Danh sách theo lọc</returns>
        /// CreatedBy CMChau 14/6/2021
        public IEnumerable<MSEntity> GetAllFilter(string textFilter);
        #endregion
    }
}
