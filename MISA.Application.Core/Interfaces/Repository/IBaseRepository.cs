using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    public interface IBaseRepository<MSEntity>
    {
        #region Declare

       
        #endregion


        #region Methods

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy CMChau 19/05/2021
        public IEnumerable<MSEntity> GetAll();


        /// <summary>
        /// Lấy thông tin của 1 bản ghi 
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <returns>Thông tin chi tiết của 1 bản ghi</returns>
        /// CreatedBy CMChau 19/05/2021
        public MSEntity GetById(Guid entityId);

        /// <summary>
        /// Cập nhật thông tin của 1 bản ghi
        /// </summary>
        /// <param name="entity">Thông tin của bản ghi</param>
        /// <param name="entityid">Id của bản ghi cần sửa</param>
        /// <returns>Số dòng đã update trong database</returns>
        /// CreatedBy CMChau 19/05/2021
        public int Update(MSEntity entity, Guid entityid);

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">thông tin của 1 bản ghi</param>
        /// <returns>Số dòng đã thêm được vào database</returns>
        /// CreatedBy CMChau 19/05/2021
        public int Insert(MSEntity entity);

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <returns>Số dòng đã xóa</returns>
        /// CreatedBy CMChau 19/05/2021
        public int DeleteById(Guid entityId);

        /// <summary>
        /// Lấy ra tổng số bản ghi sau khi lọc
        /// </summary>
        /// <param name="textFilter">Từ khóa lọc</param>
        /// <returns>Tổng số bản ghi</returns>
        /// CreatedBy CMChau 11/06/2021
        public int GetCountFilter(string textFilter);

        /// <summary>
        /// Lấy ra mã mới nhất từ trong hệ thống
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
        public IEnumerable<MSEntity> GetPagingFilter(int pageIndex, int pageSize, string textFilter);

        /// <summary>
        /// Lấy toàn bộ danh sách theo lọc
        /// </summary>
        /// <param name="textFilter">Từ khóa lọc</param>
        /// <returns>Danh sách theo lọc</returns>
        /// CreatedBy CMChau 14/6/2021
        public IEnumerable<MSEntity> GetAllFilter(string textFilter);

        /// <summary>
        /// Kiểm tra trùng mã 
        /// </summary>
        /// <param name="EntityCode">Mã cần kiểm tra</param>
        /// <returns>True - mã bị trùng,false - mã không bị trùng</returns>
        /// CreatedBy CMChau 12/06/2021
        public bool CheckCodeExist(string entityCode,Guid? entityId=null);
        #endregion
    }
}
