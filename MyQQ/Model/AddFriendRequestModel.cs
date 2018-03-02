using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{
    public class AddFriendRequestModel : CommonRequestModel
    {
        public int targetId { get; set; }
        public String mess { get; set; }
         
    }
}