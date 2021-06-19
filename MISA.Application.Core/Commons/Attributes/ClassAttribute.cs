using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Commons.Attributes
{

    #region ClassAttribute
    /// <summary>
    /// Tạo attribute để validate dữ liệu
    /// </summary>
    /// CreatedBY CMChau 16/6/2021
    [AttributeUsage(AttributeTargets.Property)]
    // Kiểm tra dữ liệu trống
    public class MSRequired : Attribute
    {
        public string Msg;
        public MSRequired(string msg)
        {
            Msg = msg;
        }
    }
    /// <summary>
    /// Kiểm tra trùng dữ liệu
    /// </summary>
    /// CreatedBY CMChau 16/6/2021
    public class MSDuplicate : Attribute
    {
        public string ErrorMsg;
        public MSDuplicate(string msg)
        {
            ErrorMsg = msg;
        }
    }
    #endregion
}
