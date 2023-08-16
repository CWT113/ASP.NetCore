using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_组织结构树
{
    public class OrgUnits
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public OrgUnits Parents { get; set; }
        public List<OrgUnits> Childrens { get; set; } = new List<OrgUnits>();
    }
}
