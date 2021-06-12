using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    class CustomerValidateService 
    {
        public int Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cập nhật thông tin của khách hàng theo id
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Số dòng đã cập nhật được</returns>
        public int Update(Customer customer, Guid customerId)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Check trùng số điện thoại
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>true/false</returns>
        /// Created by CMChau (19/05/2021)
        public bool CheckDuplicatePhoneNumber(string phoneNumber)
        {
            return true;
        }

       
        public bool CheckCustomerCodeExist(string customerCode)
        {
            throw new NotImplementedException();
        }
    }
}
