using SignalR.Hubs;

namespace SimpleChat.Controllers
{
    [HubName("chat")]
    public class SimpleChat : Hub
    {
        public void SendMessage(string message)
        {
            Clients.addMessage(message);
        }
    }
}