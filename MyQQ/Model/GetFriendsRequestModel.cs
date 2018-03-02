using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{

    /**
     * Created by Administrator on 2018/2/25.
     */
    public class GetFriendsRequestModel : CommonRequestModel
    {
        public int targetId { get; set;  }

    }
}