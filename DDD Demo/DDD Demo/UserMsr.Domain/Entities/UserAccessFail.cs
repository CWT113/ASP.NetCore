using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Yitter.IdGenerator;

namespace UserMsr.Domain.Entities
{
    /// <summary>
    /// 用户登录失败
    /// </summary>
    public record UserAccessFail
    {
        public long Id { get; init; }
        public User User { get; init; }
        public long UserId { get; init; }
        private bool IsLockOut1;
        /// <summary>
        /// 账户锁定
        /// </summary>
        public bool LockOut { get; private set; }
        /// <summary>
        /// 账户锁定时长
        /// </summary>
        public DateTime? LockOutEnd { get; private set; }
        /// <summary>
        /// 账户登录失败次数
        /// </summary>
        public int AccessFailCount { get; private set; }
        /// <summary>
        /// 无参构造方法，供 EFCore 使用
        /// </summary>
        public UserAccessFail() { }
        /// <summary>
        /// 有参构造方法，对用户信息赋值
        /// </summary>
        /// <param name="user"></param>
        public UserAccessFail(User user)
        {
            this.Id = YitIdHelper.NextId();
            this.User = user;
        }
        /// <summary>
        /// 重置账户
        /// </summary>
        public void Reset()
        {
            LockOut = false;
            LockOutEnd = null;
            AccessFailCount = 0;
        }
        /// <summary>
        /// 登录失败
        /// </summary>
        public void Fail()
        {
            AccessFailCount++;
            if (AccessFailCount >= 3)
            {
                LockOut = true;
                //锁定时间延长 3 分钟
                LockOutEnd = DateTime.Now.AddMilliseconds(3);
            }
        }
        /// <summary>
        /// 判断用户账户是否处于锁定状态
        /// </summary>
        /// <returns>锁定：true；未锁定：false</returns>
        public bool IsLockOut()
        {
            if (this.LockOut)
            {
                if (DateTime.Now > this.LockOutEnd)
                {
                    Reset();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        } 
    }
}
