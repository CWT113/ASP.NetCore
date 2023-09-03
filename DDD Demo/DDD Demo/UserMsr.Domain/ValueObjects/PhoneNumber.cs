using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMsr.Domain.ValueObjects
{
    /// <summary>
    /// 用户手机号码
    /// </summary>
    /// <param name="regionNumber">国家地区代码</param>
    /// <param name="Number">电话号码</param>
    public record PhoneNumber(int regionNumber, string Number);
}
