using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{
    public class SearchFriendResponseModel : CommonResponseModel
    {
        public DataList<LoginResponseModel> dataList { get; set; }
    }
}