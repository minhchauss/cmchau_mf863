using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Commons.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
   public class Required:Attribute
    {
        public string Msg;
        public Required(string msg)
        {
            Msg = msg;
        }
    }
    public class Duplicate : Attribute
    {
        public string ErrorMsg;
        public Duplicate(string msg)
        {
            ErrorMsg = msg;
        }
    }
}
