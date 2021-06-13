using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        #region Declare

        #endregion
        #region Methods
        public byte[] ExportAllData();
        #endregion
    }
}
