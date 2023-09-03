using UserMsr.Domain.Entities;
using UserMsr.Domain.Event;
using UserMsr.Domain.ValueObjects;

namespace UserMsr.Domain.Repository
{
    /// <summary>
    /// 仓储接口，只定义相关的接口，不做任何实现
    /// </summary>
    public interface IUserRepository
    {
        public Task<User?> FindOneAsync(PhoneNumber phoneNumber);
        public Task<User?> FindOneAsync(long userId);
        public Task AddNewLoginHistoryAsync(PhoneNumber phoneNumber, string message);
        public Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code);
        public Task<string?> FinePhoneNumberCodeAsync(PhoneNumber phoneNumber);
        public Task PublishEventAsync(UserAccessResultEvent _events);
    }
}
