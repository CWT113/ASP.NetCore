using UserMsr.Domain.ValueObjects;

namespace UserMsr.Domain.Repository
{
    /// <summary>
    /// 防腐层接口
    /// </summary>
    public interface ISmsCodeSender
    {
        public Task SendCodeAsync(PhoneNumber phoneNumber, string code);
    }
}
