using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Exceptions
{
    /// <summary>
    /// Tạo validate axception custom
    /// </summary>
    /// CreatedBy CMChau 16/6/2021
    public class ValidateException:Exception
    {
        /// <summary>
        /// ValidateException
        /// </summary>
        /// <param name="msg">câu thông báo</param>
        /// <param name="Data">Dữ liệu trả về</param>
        /// CreatedBy CMChau 16/6/2021
        public ValidateException(string msg,object Data=null):base(msg)
        {
            var MsgError = new
            {
                Msg = msg,
                FiledNotValid= Data

            };
            this.Data.Add("Error", MsgError);
        }
    }
}
