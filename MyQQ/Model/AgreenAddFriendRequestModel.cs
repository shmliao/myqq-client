using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{
    public class AgreenAddFriendRequestModel : CommonRequestModel
    {
        public int targetId { get; set; }
        public int result { get; set; }
        public String resultMess { get; set; }

    }
}