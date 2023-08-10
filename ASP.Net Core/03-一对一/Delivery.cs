using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_一对一
{
    public class Delivery
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public Order Order { get; set; }

        //必须新建一个 OrderId
        public long OrderId { get; set; }
    }
}
