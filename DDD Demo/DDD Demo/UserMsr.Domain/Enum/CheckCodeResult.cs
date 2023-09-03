using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMsr.Domain.Enum
{
    public enum CheckCodeResult
    {
        [Display(Name = "验证码正确")]
        OK = 1,
        [Display(Name = "电话号码不存在")]
        PhoneNumberNotFound = 2,
        [Display(Name = "账户被锁定")]
        LockOut = 3,
        [Display(Name = "验证码错误")]
        CodeError = 4
    }
}
