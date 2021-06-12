using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    /// <summary>
    /// Repository khách hàng
    /// </summary>
    /// Created by CMChau (20/05/2021)
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        #region Methods

        ///// <summary>
        ///// Kiểm tra trùng CustomerCode
        ///// </summary>
        ///// <param name="customerCode">Mã khách hàng</param>
        ///// <returns> true - trùng mã, false - không trùng mã</returns>
        ///// Created by CMChau (19/05/2021)
        //bool CheckCustomerCodeExist(string customerCode, Guid? customerId = null);

        ///// <summary>
        ///// validate dữ liệu khách hàng
        ///// </summary>
        ///// <param name="customer">thông tin được truyền lên từ client</param>
        ///// Created by CMChâu 21/05/2021
        //void ValidateCustomer(Customer customer);
        #endregion

    }
}
