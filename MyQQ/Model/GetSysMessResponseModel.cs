using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{
    public class GetSysMessResponseModel : CommonResponseModel
    {
        //来源0系统 其他是其他用户的产生的
        public int fromId { get; set; }
        public String fromNickName { get; set; }
        /// <summary>
        /// 0系统 1申请加好友 2同意好友申请 3拒绝好友申请 4好友下线 5好友上线
        /// </summary>
        public int sysMessType { get; set; }
        //消息内容
        public String content { get; set; }
        public int faceimg { get; set; }
    }
}