using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_MySQL并发控制
{
    public class House
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }

        //多乐观并发控制字段
        public byte[] RowVersion { get; set; }
    }
}
