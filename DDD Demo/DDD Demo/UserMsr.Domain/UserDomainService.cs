using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMsr.Domain.Entities;
using UserMsr.Domain.Enum;
using UserMsr.Domain.Repository;
using UserMsr.Domain.ValueObjects;

namespace UserMsr.Domain
{
    /// <summary>
    /// 领域层服务
    /// </summary>
    public class UserDomainService
    {
        //注入仓储层接口
        private readonly IUserRepository userRepository;
        private readonly ISmsCodeSender smsCodeSender;
        private UserDomainService(IUserRepository userRepository, ISmsCodeSender smsCodeSender)
        {
            this.userRepository = userRepository;
            this.smsCodeSender = smsCodeSender;
        }

        /// <summary>
        /// 验证登录信息
        /// </summary>
        /// <param name="phoneNumber">电话号码</param>
        /// <param name="password">密码</param>
        /// <returns>用户登录状态枚举值</returns>
        public async Task<UserAccessResult> CheckLoginAsync(PhoneNumber phoneNumber, string password)
        {
            //使用电话号码查找用户
            User? user = await userRepository.FindOneAsync(phoneNumber);
            //记录登录结果
            UserAccessResult result;

            if (user == null)
            {
                result = UserAccessResult.PhoneNumberNotFound;
            }
            else if (IsLockOut(user))
            {
                result = UserAccessResult.LockOut;
            }
            else if (user.IsHasPassword() == false)
            {
                result = UserAccessResult.NoPassword;
            }
            else if (user.CheckPasswrod(password))
            {
                result = UserAccessResult.OK;
            }
            else
            {
                result = UserAccessResult.PasswordError;
            }

            if (user != null)
            {
                if (result == UserAccessResult.OK)
                {
                    ResetAccessFail(user);
                }
                else
                {
                    AccessFail(user);
                }
            }

            //发布事件
            await userRepository.PublishEventAsync(new Event.UserAccessResultEvent(phoneNumber, result));
            return result;
        }

        public async Task<CheckCodeResult> CheckPhoneNumberCodeAsync(PhoneNumber phoneNumber, string code)
        {
            User? user = await userRepository.FindOneAsync(phoneNumber);
            if (user == null)
            {
                return CheckCodeResult.PhoneNumberNotFound;
            }
            else if(IsLockOut(user))
            {
                return CheckCodeResult.LockOut;
            }

            string? codeInserver = await userRepository.FinePhoneNumberCodeAsync(phoneNumber);
            if (codeInserver == null)
            {
                AccessFail(user);
                return CheckCodeResult.CodeError;
            }
            if (codeInserver == code)
            {
                return CheckCodeResult.OK;
            }
            else
            {
                AccessFail(user);
                return CheckCodeResult.CodeError;
            }
        }

        public void ResetAccessFail(User user)
        {
            user.UserAccessFail.Reset();
        }

        public bool IsLockOut(User user)
        {
            return user.UserAccessFail.IsLockOut();
        }

        public void AccessFail(User user)
        {
            user.UserAccessFail.Fail();
        }
    }
}
