using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{
    public class GetOffLineChatMessResponseModel : CommonResponseModel
    {
        public int fromid { get; set; }
        public String nickName { get; set; }
        public int ChatMessType { get; set; }
        public String content { get; set; }
        public DateTime createtime { get; set; }
        public int faceimg { get; set; }
    }
}