using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ.Model
{
    public class DataList<T>
    {
        public DataList(int pageSize, int total)
        {
            this.pageSize = pageSize;
            this.total = total;
            this.pageCount = total % pageSize == 0 ? total / pageSize : total / pageSize + 1;
        }
        public int total { get; set; }
        public int pageCount { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public List<T> data { get; set; }
    }
}