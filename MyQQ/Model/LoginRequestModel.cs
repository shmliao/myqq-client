using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{

    public class LoginRequestModel : CommonRequestModel
    {
        public String username { get; set; }
        public String userpass { get; set; }
    }
}