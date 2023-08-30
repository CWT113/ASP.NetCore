using MediatR;

namespace _08_MediatR
{
    public class PostNotiHandler1 : NotificationHandler<PostNotification>
    {
        protected override void Handle(PostNotification notification)
        {
            Console.WriteLine("111：" + notification.Name);
        }
    }
}
