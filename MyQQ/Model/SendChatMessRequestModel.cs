using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{
    public class SendChatMessRequestModel : CommonRequestModel
    {
        public int targetId { get; set; }
        //0 是私聊 1 是群聊
        public int targetType { get; set; }
        public String content { get; set; }
    }
}