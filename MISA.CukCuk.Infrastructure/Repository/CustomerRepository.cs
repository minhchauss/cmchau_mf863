using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using MISA.CukCuk.Infrastructure.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.CustomerRepos.Repository
{
    public class CustomerRepository : BaseRepository<Customer>,ICustomerRepository
    {
        #region Declare
        ICustomerRepository _customerRepository;
        public CustomerRepository(IConfiguration configuration):base(configuration)
        {

        }
        #endregion

        #region Method

        #endregion
    }
}
