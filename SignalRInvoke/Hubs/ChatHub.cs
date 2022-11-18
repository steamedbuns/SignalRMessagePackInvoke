using Microsoft.AspNetCore.SignalR;

namespace SignalRInvoke.Hubs
{
    public class ChatHub : Hub<ICustomClient>
    {
        public async Task InvokeMessage(string user, string message)
        {
            Console.WriteLine("Hub.InvokeMessage: method entry.");
            // System.Exception thrown here after the client returned bool value.
            try
            {
                bool result = await Clients.Caller.ReceiveMessageInvoke(user, message);
                Console.WriteLine($"Hub.InvokeMessage: method exit. Result: {result}.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hub.InvokeMessage: method exit. Exception: {e.Message}.");
            }
        }
    }
}
