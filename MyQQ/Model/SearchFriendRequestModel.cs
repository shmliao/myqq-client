using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{

    public class SearchFriendRequestModel : CommonRequestModel
    {
        public String keyWord { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}