using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{


    public class GetFriendsResponseModel : CommonResponseModel
    {
        public int friendid { get; set; }
        public String nickName { get; set; }
        public int lineState { get; set; }

        public int faceimg { get; set; }

    }
}