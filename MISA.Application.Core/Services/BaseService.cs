using MISA.CukCuk.Core.Commons.Attributes;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Enum;
using MISA.CukCuk.Core.Interfaces.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class BaseService<MSEntity> : IBaseService<MSEntity>
    {
        #region Declare
        
        protected IBaseRepository<MSEntity> _baseRepository;
        public BaseService(IBaseRepository<MSEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IEnumerable<MSEntity> GetAllFilter(string textFilter)
        {
            var entities = _baseRepository.GetAllFilter(textFilter);
            return entities;
        }
        #endregion


        #region Methods


        public virtual string GetNewCode()
        {
            // Lấy ra mã mới nhất
            var lastestCode = _baseRepository.GetNewCode();
            // Lấy độ dài chuỗi
            var codeLength = lastestCode.Length;
            // Chặt chuỗi lấy 3 ký tự đầu tiên
            string result = lastestCode.Substring(0, 3);

            // Nếu chuỗi mới nhất tị vị trí i có ký tự 0 thì cộng thêm vào chuỗi đã chặt 
            // while (lastestCode[i] == '0' && i < codeLength)
            //{
            //    result = result + '0';
            //    i++;
            //}
            for (int i = 3; i < codeLength; i++)
            {
                if (lastestCode[i] == '0')
                    result = result + '0';
                else
                    break;
            }
            // Lấy chuỗi sau khi chặt và bỏ 0
            var resString = lastestCode.Substring(codeLength - result.Length - 1);
            int resInt = int.Parse(resString) + 1;
            // Cộng lại vào chuỗi đã chặt ban đầu
            result = result + resInt.ToString();
            return result;


        }

        public PaggingData<MSEntity> GetPagingFilter(int pageIndex, int pageSize, string textFilter)
        {
            var PagingResult = new PaggingData<MSEntity>();
            // Kiểm tra trang hiện tại có lớn hơn 0
            if (pageIndex <= 0)
                throw new ValidateException(Properties.Resources.Error_PageIndex, pageIndex);
            // Kiểm tra số bản ghi/trang có lớn hơn 0
            if (pageSize <= 0)
                throw new ValidateException(Properties.Resources.Error_PageSize, pageSize);

            pageSize = pageSize > 100 ? 100 : pageSize;
            PagingResult.Items = _baseRepository.GetPagingFilter(pageIndex, pageSize, textFilter);
            PagingResult.TotalCount = _baseRepository.GetCountFilter(textFilter);
            return PagingResult;
        }


        public int Insert(MSEntity entity)
        {
            // Gán trạng thái hiện tại của đối tượng là Insert
            var properties = typeof(MSEntity).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name == "EntityState")
                {
                    property.SetValue(entity, Enum.EntityState.INSERT);
                }
                if (property.Name == $"{typeof(MSEntity)}Id")
                {
                    property.SetValue(entity, Guid.NewGuid());
                }
            }
            CheckValidateData(entity);
            var rowAffects = _baseRepository.Insert(entity);
            return rowAffects;
        }

        public int Update(MSEntity entity, Guid entityid)
        {
            var properties = typeof(MSEntity).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name == "EntityState")
                {
                    property.SetValue(entity, Enum.EntityState.UPDATE);
                }
            }
            CheckValidateData(entity);
            var rowAffects = _baseRepository.Update(entity, entityid);
            return rowAffects;
        }


        /// <summary>
        /// Kiểm tra validate dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu cần kiểm tra</param>
        /// CreatedBy CMChau 12/06/2021
        protected virtual void CheckValidateData(MSEntity entity)
        {
            var properties = typeof(MSEntity).GetProperties();
            foreach (var property in properties)
            {
                // Lấy ra attribute
                var attributeRequired = property.GetCustomAttributes(typeof(MSRequired), true);
                var attributeDuplicate = property.GetCustomAttributes(typeof(MSDuplicate), true);
                // Kiểm tra có nhập dữ liệu hay không
                if (attributeRequired.Length > 0)
                {
                    // Lấy giá trị propety
                    var propValue = property.GetValue(entity).ToString();
                    // Lấy kiểu của property
                    var propType = property.GetType().Name;
                    // Kiểm tra property có hợp lệ không
                    if (propValue.Length == 0)
                    {
                        // Lấy ra câu thông báo lỗi 
                        var msg = (attributeRequired[0] as MSRequired).Msg;
                        throw new ValidateException(msg, propType);
                    }
                }
            }
        }
        #endregion
    }
}
