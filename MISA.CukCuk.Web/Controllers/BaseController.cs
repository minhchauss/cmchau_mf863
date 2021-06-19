using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    /// <summary>
    /// Controller dùng chung
    /// </summary>
    /// <typeparam name="MSEntity"></typeparam>
    /// CreatedBy CMChau 17/6/2021
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseController<MSEntity> : ControllerBase
    {

        #region Declare
        IBaseRepository<MSEntity> _baseRepository;
        IBaseService<MSEntity> _baseService;
        public BaseController(IBaseRepository<MSEntity> baseRepository, IBaseService<MSEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion


        #region Methods Api

        /// <summary>
        /// Lấy toàn bộ danh sách các bản ghi
        /// </summary>
        /// 200 - Tất cả dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception hệ thống
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy CMChau 12/6/2021
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _baseRepository.GetAll();
            if (entities.Count() > 0)
                return Ok(entities);
            else
                return NoContent();
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// 200 - Thông tin bản ghi
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception hệ thống
        /// <returns>Thông tin bản ghi</returns>
        /// CreatedBy CMChau 12/6/2021
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var entity = _baseRepository.GetById(id);
            if (entity != null)
                return Ok(entity);
            else
                return NoContent();
        }

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// 200 - Số dòng đã thêm mới được
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception hệ thống
        /// <returns>Số dòng thêm mới</returns>
        /// CreatedBy CMChau 12/6/2021
        [HttpPost]
        public IActionResult Insert( MSEntity entity)
        {
            var res = _baseService.Insert(entity);
            if (res > 0)
                return Ok(res);
            else
                return NoContent();
        }

        /// <summary>
        /// Cập nhật thông tin 1 bản ghi
        /// </summary>
        /// 200 - Số dòng đã sửa được
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception hệ thống
        /// <returns>Số dòng đã sửa</returns>
        /// CreatedBy CMChau 12/6/2021
        [HttpPut("{id}")]
        public IActionResult Update([FromBody]MSEntity entity,Guid id)
        {
            var res = _baseService.Update(entity, id);
            if (res > 0)
                return Ok(res);
            else
                return NoContent();
        }


        /// <summary>
        /// Xóa 1 bản ghi theo id
        /// </summary>
        /// 200 - Số dòng đã xóa
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception hệ thống
        /// <returns>Số dòng đã xóa được</returns>
        /// CreatedBy CMChau 12/6/2021
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var res = _baseRepository.DeleteById(id);
            if (res > 0)
                return Ok(res);
            else
                return NoContent();
        }


        /// <summary>
        /// Lấy danh sách bản ghi theo lọc + phân trang
        /// </summary>
        /// 200 - Danh sách bản ghi theo lọc phân trang
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception hệ thống
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy CMChau 12/6/2021
        [HttpGet("paging")]
        public IActionResult GetPaging(int pageIndex,int pageSize,string textFilter)
        {
            var entities = _baseService.GetPagingFilter(pageIndex, pageSize, textFilter);
            if (entities.Items.Count() > 0)
                return Ok(entities);
            else
                return NoContent();
        }

        /// <summary>
        /// Lấy ra mã code lớn nhất cộng thêm 1
        /// </summary>
        /// 200 - Mã code lớn nhất
        /// 204 - Không có dữ liệu
        /// 400 - Dữ liệu không hợp lệ
        /// 500 - Exception hệ thống
        /// <returns>Mã code tự động lớn nhất</returns>
        /// CreatedBy CMChau 12/6/2021
        [HttpGet("newcode")]
        public IActionResult GetNewCode()
        {
            var res = _baseService.GetNewCode();
            return Ok(res);
        }

        #endregion
    }
}
