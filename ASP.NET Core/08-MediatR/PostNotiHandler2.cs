using MediatR;

namespace _08_MediatR
{
    public class PostNotiHandler2 : NotificationHandler<PostNotification>
    {
        protected override void Handle(PostNotification notification)
        {
            Console.WriteLine("222：" + notification.Name);
        }
    }
}
