using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{

    public class CommonMess
    {
        public int messType { get; set; }
        public String content { get; set; }
        [JsonIgnoreAttribute]
        public Action<bool> action { get; set; }
    }
}