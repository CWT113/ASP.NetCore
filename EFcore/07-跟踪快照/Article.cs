﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _07_跟踪快照
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public double Price { get; set; }
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDeleted { get; set; }

        public List<Comment> comments { get; set; } = new List<Comment>();
    }
}
