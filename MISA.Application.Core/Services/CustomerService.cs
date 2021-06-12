using MISA.CukCuk.Core.Entities;
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
    public class CustomerService : BaseService<Customer>,ICustomerService
    {

        #region Declare

        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion


        #region Methods

        /// <summary>
        /// Validate dữ liệu khách hàng
        /// </summary>
        /// <param name="customer">thông tin khách hàng</param>
        /// CreatedBy CMChau 11/6/2021
        void ValidateCustomer(Customer customer)
        {
            var isDuplicate = false;
            if (customer.EntityState == Enum.EntityState.Add)
                //Check dữ liệu  khách hàng
                isDuplicate = _customerRepository.CheckCodeExist(customer.CustomerCode, customer.CustomerId);
            if (isDuplicate == true)
            {
                throw new ValidateException("Mã đã tồn tại", customer.GetType().GetProperty("CustomerCode").Name);
            }
        }
        #endregion

    }
}
