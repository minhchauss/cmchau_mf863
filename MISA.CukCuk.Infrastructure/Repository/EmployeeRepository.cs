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
        IDbConnection _dbConnection;
        readonly string _connectionString;
        DynamicParameters Parameters = new DynamicParameters();
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {
            
        }

        #endregion
        #region Methods
        public bool CheckEmployeePhoneNumber(string phoneNumber,Guid? employeeId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(Employee).Name;
                // Khai báo Procedure
                var sqlCommand = $"Proc_Check{tableName}PhoneNumberExist";
                // Truyền tham số
                Parameters.Add($"m_PhoneNumber", phoneNumber);
                Parameters.Add($"m_{tableName}Id", employeeId);
                var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, Parameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public bool CheckEmployeeIdentityNo(string identityNo, Guid? employeeId)
        {
            var tableName = typeof(Employee).Name;
            // Khai báo Procedure
            var sqlCommand = $"Proc_Check{tableName}IdentityNoExist";
            // Truyền tham số
            Parameters.Add($"m_IdentityNo", identityNo);
            Parameters.Add($"m_{tableName}Id", employeeId);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, Parameters, commandType: CommandType.StoredProcedure);
            return res;
        }



        #endregion


    }
}
