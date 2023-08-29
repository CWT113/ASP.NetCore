using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_充血模型
{
    public class Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
    }

    public enum Type
    {
        CNY,
        USD,
        DZY
    }
}
