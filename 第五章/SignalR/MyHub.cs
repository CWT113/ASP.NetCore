using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    public class MyHub : Hub
    {
        public Task SendPublicMsg(string message)
        {
            string connId = this.Context.ConnectionId;
            string msg = $"{connId} {DateTime.Now}: {message}";
            return this.Clients.All.SendAsync("PublicMsgReceived", msg, 666);
        }
    }
}
