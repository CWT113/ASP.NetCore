using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_基本使用
{
    class Comment
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public Article Article { get; set; }
    }
}
