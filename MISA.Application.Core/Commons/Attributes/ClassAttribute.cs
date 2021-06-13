using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Commons.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
   public class MSRequired:Attribute
    {
        public string Msg;
        public MSRequired(string msg)
        {
            Msg = msg;
        }
    }
    public class MSDuplicate : Attribute
    {
        public string ErrorMsg;
        public MSDuplicate(string msg)
        {
            ErrorMsg = msg;
        }
    }
}
