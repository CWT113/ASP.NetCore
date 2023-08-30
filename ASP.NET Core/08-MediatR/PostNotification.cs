using MediatR;

namespace _08_MediatR
{
    public record PostNotification(string Name) : INotification;
}
