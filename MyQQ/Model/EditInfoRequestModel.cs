using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{

    public class EditInfoRequestModel : CommonRequestModel
    {

        public int age { get; set; }

        public String gender { get; set; }

        public String userpass { get; set; }

        public String nickname { get; set; }

        public String conste { get; set; }

        public String blood { get; set; }

        public int faceimg { get; set; }
    }
}