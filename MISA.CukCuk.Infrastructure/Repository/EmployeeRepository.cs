using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>,IEmployeeRepository
    {
        #region Declare
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {

        }
        #endregion


      
    }
}
