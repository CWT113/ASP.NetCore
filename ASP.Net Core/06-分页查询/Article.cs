using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _06_分页查询
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public double Price { get; set; }

        public List<Comment> comments { get; set; } = new List<Comment>();
    }
}
