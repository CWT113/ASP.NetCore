using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using UserMsr.Domain.Entities;
using UserMsr.Domain.Event;
using UserMsr.Domain.Repository;
using UserMsr.Domain.ValueObjects;

namespace UserMsr.Infrastracture
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext dBContext;
        private readonly IDistributedCache distributedCache;
        private readonly IMediator mediator;

        public UserRepository(UserDBContext dBContext, IDistributedCache distributedCache, IMediator mediator)
        {
            this.dBContext = dBContext;
            this.distributedCache = distributedCache;
            this.mediator = mediator;
        }

        public async Task AddNewLoginHistoryAsync(PhoneNumber phoneNumber, string message)
        {
            User? user = await FindOneAsync(phoneNumber);
            long? userId = null;
            if (user != null) userId = user.Id;
            dBContext.UserLoginHistories.Add(new UserLoginHistory(userId, phoneNumber, message));
        }

        public async Task<User?> FindOneAsync(PhoneNumber phoneNumber)
        {
            User? user = await dBContext.Users.SingleOrDefaultAsync(d => 
                d.PhoneNumber.regionNumber == phoneNumber.regionNumber && 
                d.PhoneNumber.Number == phoneNumber.Number);
            return user;
        }

        public async Task<User?> FindOneAsync(long userId)
        {
            User? user = await dBContext.Users.SingleOrDefaultAsync(d => d.Id == userId);
            return user;
        }

        public async Task<string?> FinePhoneNumberCodeAsync(PhoneNumber phoneNumber)
        {
            string key = $"PhoneNumberCode_{phoneNumber.regionNumber}_{phoneNumber.Number}";
            string? code = await distributedCache.GetStringAsync(key);
            distributedCache.Remove(key);
            return code;
        }

        public Task PublishEventAsync(UserAccessResultEvent _events)
        {
            return mediator.Publish(_events);
        }

        public Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code)
        {
            string key = $"PhoneNumberCode_{phoneNumber.regionNumber}_{phoneNumber.Number}";
            return distributedCache.SetStringAsync(key, code, 
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
        }
    }
}
