using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{
    public class LoginResponseModel : CommonResponseModel
    {
        public String username { get; set; }

        public int age { get; set; }

        public String gender { get; set; }

        public String nickname { get; set; }

        public String conste { get; set; }

        public String blood { get; set; }

        public DateTime createtime { get; set; }
        public int id { get; set; }
        public int lineState { get; set; }

        public int faceimg { get; set; }
    }
}
