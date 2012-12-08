using Microsoft.AspNet.SignalR.Hubs;

namespace SimpleChat.Controllers
{
    [HubName("chat")]
    public class SimpleChat : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.addMessage(message);
        }
    }
}