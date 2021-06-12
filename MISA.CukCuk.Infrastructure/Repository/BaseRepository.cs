using Dapper;
using Microsoft.Extensions.Configuration;
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
    public class BaseRepository<MSEntity> : IBaseRepository<MSEntity>
    {
        #region Declare

        /// <summary>
        /// Khởi tạo chuỗi kết nối đến database
        /// </summary>
        /// CreatedBy CMChau 12/06/2021
        IDbConnection _dbConnection;
        readonly string _connectionString;
        IConfiguration _configuration;
        DynamicParameters Parameters;
        string _className = typeof(MSEntity).Name;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region Methods


        public IEnumerable<MSEntity> GetAll()
        {

            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // Gọi procedure
                var sqlCommand = $"Proc_Get{_className}s";
                // Tiến hành lấy danh sách
                var entities = _dbConnection.Query<MSEntity>(sqlCommand, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }


        public MSEntity GetById(Guid id)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                //Gọi procedure
                var sqlCommand = $"Proc_Get{_className}ById";
                // Thêm param
                Parameters.Add($"m_{_className}Id", id);
                // Trả về thông tin của bản ghi
                var entity = _dbConnection.QueryFirstOrDefault<MSEntity>(sqlCommand, param: Parameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }


        public int Insert(MSEntity entity)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // Gọi procedure
                var sqlCommnad = $"Proc_Insert{_className}";
                // Tiến hành thêm mới 
                var rowEffect = _dbConnection.Execute(sqlCommnad, param: entity, commandType: CommandType.StoredProcedure);
                return rowEffect;
            }
        }


        public int Update(MSEntity entity, Guid id)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // Gọi procedure
                var sqlCommnad = $"Proc_Update{_className}";
                // Kiểm tra id của bản ghi có tồn tại không
                var entityPropertyName = $"{_className}Id";
                var entityPropertyId = typeof(MSEntity).GetProperty(entityPropertyName);
                if (entityPropertyId != null)
                    entityPropertyId.SetValue(entity, id);
                // Tiến hành update thông tin
                var rowAffect = _dbConnection.Execute(sqlCommnad, param: entity, commandType: CommandType.StoredProcedure);
                return rowAffect;
            }
        }


        public int DeleteById(Guid id)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // Gọi procedure
                var sqlCommnad = $"Proc_Delete{_className}";
                // Thêm param
                Parameters.Add($"p_{_className}Id", id);
                // Tiến hành xóa
                var rowEffect = _dbConnection.Execute(sqlCommnad, param: Parameters, commandType: CommandType.StoredProcedure);
                return rowEffect;
            }
        }


        public string GetNewCode()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // Gọi procedure
                var sqlCommnad = $"Proc_GetNew{_className}Code";
                // 
                var entities = _dbConnection.QueryFirstOrDefault<string>(sqlCommnad, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }


        public IEnumerable<MSEntity> GetPagingFilter(int pageIndex, int pageSize, string textFilter)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // Gọi procedure
                var sqlCommnad = $"Proc_Get{_className}sPagingFilter";
                Parameters.Add($"m_PageIndex", pageIndex);
                Parameters.Add($"m_PageSize", pageSize);
                Parameters.Add($"m_FullName", textFilter);
                Parameters.Add($"m_{_className}Code", textFilter);
                Parameters.Add($"m_PhoneNumber", textFilter);
                var entities = _dbConnection.Query<MSEntity>(sqlCommnad, param: Parameters, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }



        public int GetCountFilter(string textFilter)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // Gọi procedure
                var sqlCommnad = $"Proc_GetCount{_className}sFilter";
                //Truyền param
                Parameters.Add($"m_FullName", textFilter);
                Parameters.Add($"m_{_className}Code", textFilter);
                var countNumber = _dbConnection.QueryFirstOrDefault<int>(sqlCommnad, param: Parameters, commandType: CommandType.StoredProcedure);
                return countNumber;
            }
        }


        /// <summary>
        /// Kiểm tra mã đã tồn tại trong hệ thống hay chưa
        /// </summary>
        /// <param name="EntityCode">Mã kiểm tra</param>
        /// <returns>True - bị trùng, False - không bị trùng</returns>
        public bool CheckCodeExist(string entityCode,Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // Khai báo Procedure
                var sqlCommand = $"Proc_Check{_className}CodeExist";
                // Truyền tham số
                Parameters.Add($"m_{_className}Code", entityCode);
                Parameters.Add($"m_{_className}Id", entityId);
                var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, Parameters, commandType: CommandType.StoredProcedure);
                return res;

            }
        }
        #endregion
    }
}
