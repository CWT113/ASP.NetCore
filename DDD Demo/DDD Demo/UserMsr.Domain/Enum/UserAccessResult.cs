using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMsr.Domain.Enum
{
    /// <summary>
    /// 用户登录状态枚举
    /// </summary>
    public enum UserAccessResult
    {
        [Display(Name = "登录成功")]
        OK = 1,
        [Display(Name = "密码不存在")]
        PhoneNumberNotFound = 2,
        [Display(Name = "账户被锁定")]
        LockOut = 3,
        [Display(Name = "暂无此密码")]
        NoPassword = 4,
        [Display(Name = "密码错误")]
        PasswordError = 5
    }
}
