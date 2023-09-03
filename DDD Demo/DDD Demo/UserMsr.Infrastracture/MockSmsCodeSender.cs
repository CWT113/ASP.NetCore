using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMsr.Domain.Repository;
using UserMsr.Domain.ValueObjects;

namespace UserMsr.Infrastracture
{
    public class MockSmsCodeSender : ISmsCodeSender
    {
        public Task SendCodeAsync(PhoneNumber phoneNumber, string code)
        {
            Console.WriteLine($"向{phoneNumber.regionNumber} -- {phoneNumber.Number} 发送验证码 {code}，五分钟内有效，请勿提供给他人使用");
            return Task.CompletedTask;
        }
    }
}
