using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_基于关系的复杂查询
{
    public class Comment
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public Article Article { get; set; }
    }
}
