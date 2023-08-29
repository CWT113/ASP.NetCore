using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zack.Commons;

namespace _07_充血模型
{
    public class User
    {
        public long Id { get; init; }
        public DateTime CreateDateTime { get; init; }
        public string UserName { get; private set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Credits { get; set; }
        private string? PasswordHash;

        public string? remark;
        public string? Remark
        {
            get
            {
                return this.remark;
            }
        }
        public string? Tag { get; set; }

        public User() { }

        public User(string mingzi)
        {
            this.UserName = mingzi;
            this.CreateDateTime = DateTime.Now;
            this.Credits = 10;
        }

        public void ChangeUserName(string mz)
        {
            if (mz.Length > 5)
            {
                Console.WriteLine("用户名长度不能大于5！");
                return;
            }
            this.UserName = mz;
        }

        public void ChangePassword(string pwd)
        {
            if (pwd.Length < 3)
            {
                Console.WriteLine("密码长度不能小于3！");
                return;
            }
            this.PasswordHash = HashHelper.ComputeMd5Hash(pwd);
        }
    }
}
