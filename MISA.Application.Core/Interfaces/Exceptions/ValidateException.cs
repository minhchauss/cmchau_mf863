using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Exceptions
{
   public class ValidateException:Exception
    {
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
