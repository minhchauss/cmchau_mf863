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

        IBaseRepository<MSEntity> _baseRepository;
        public BaseService(IBaseRepository<MSEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion


        #region Methods


        public virtual string GetNewCode()
        {

            var newCode = _baseRepository.GetNewCode();
            return newCode;

        }

        public int Insert(MSEntity entity)
        {
            CheckValidateData(entity);
            var rowAffects = _baseRepository.Insert(entity);
            return rowAffects;
        }

        public int Update(MSEntity entity, Guid entityid)
        {
            CheckValidateData(entity);
            var rowAffects = _baseRepository.Update(entity, entityid);
            return rowAffects;
        }

        /// <summary>
        /// Kiểm tra validate dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu cần kiểm tra</param>
        /// CreatedBy CMChau 12/06/2021
        protected void CheckValidateData(MSEntity entity)
        {

        }
        #endregion
    }
}
