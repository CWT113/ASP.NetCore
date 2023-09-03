using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMsr.Domain.ValueObjects;

namespace UserMsr.Domain.Entities
{
    /// <summary>
    /// 用户登录历史
    /// </summary>
    public class UserLoginHistory:IAggregateRoot
    {
        public long Id { get; init; }
        /// <summary>
        /// 物理外键，指向 User 的 Id
        /// </summary>
        public long? UserId { get; init; }
        public PhoneNumber PhoneNumber { get; init; }
        public DateTime CreateTime { get; init; }
        /// <summary>
        /// 记录用户登录成功或失败
        /// </summary>
        public string Message { get; init; }
        /// <summary>
        /// 无参构造函数，供 EFCore 使用
        /// </summary>
        private UserLoginHistory() { }
        /// <summary>
        /// 有参构造函数，对用户信息赋值
        /// </summary>
        /// <param name="userId">物理外键指向的用户Id</param>
        /// <param name="phoneNumber">电话号码</param>
        /// <param name="message">登录成功/失败</param>
        public UserLoginHistory(long? userId, PhoneNumber phoneNumber, string message)
        {
            this.UserId = userId;
            this.PhoneNumber = phoneNumber;
            this.CreateTime = DateTime.Now;
            this.Message = message;
        }
    }
}
