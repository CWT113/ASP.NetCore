using MediatR;
using UserMsr.Domain.Enum;
using UserMsr.Domain.ValueObjects;

namespace UserMsr.Domain.Event
{
    public record UserAccessResultEvent(PhoneNumber PhoneNumber, UserAccessResult result) : INotification;
}
