using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMsr.Domain.ValueObjects;
using Yitter.IdGenerator;
using Zack.Commons;

namespace UserMsr.Domain.Entities
{
    public class User: IAggregateRoot
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public PhoneNumber PhoneNumber { get; private set; }
        /// <summary>
        /// 用户密码散列值
        /// </summary>
        private string? PasswosrdHash;
        /// <summary>
        /// 用户登录失败
        /// </summary>
        public UserAccessFail UserAccessFail { get; private set; }
        /// <summary>
        /// 无参构造函数，供 EFCore 使用
        /// </summary>
        public User() { }
        /// <summary>
        /// 有参构造函数，对用户信息赋值
        /// </summary>
        /// <param name="phoneNumber"></param>
        public User(PhoneNumber phoneNumber)
        {
            this.Id = YitIdHelper.NextId();
            this.PhoneNumber = phoneNumber;
            this.UserAccessFail = new UserAccessFail(this);
        }
        /// <summary>
        /// 判断密码是否为空
        /// </summary>
        /// <returns>密码为空：true；密码不为空：false</returns>
        public bool IsHasPassword()
        {
            return !string.IsNullOrEmpty(this.PasswosrdHash);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ChangePassword(string password)
        {
            if (password.Length <= 3)
            {
                throw new ArgumentOutOfRangeException("密码长度须大于3!");
            }
            this.PasswosrdHash = HashHelper.ComputeMd5Hash(password);
        } 
        /// <summary>
        /// 密码校验
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns>密码相同：true；密码不同：false</returns>
        public bool CheckPasswrod(string password)
        {
            return this.PasswosrdHash == HashHelper.ComputeMd5Hash(password);
        }
        /// <summary>
        /// 修改电话号码
        /// </summary>
        /// <param name="phoneNumber">电话号码</param>
        public void ChangePhoneNumber(PhoneNumber phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }
    }
}
