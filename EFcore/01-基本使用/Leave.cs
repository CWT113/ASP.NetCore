﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_基本使用
{
    public class Leave
    {
        public long Id { get; set; }
        public User Applicant { get; set; }
        public User Approver { get; set; }
        public string Remarks { get; set; }
    }
}
