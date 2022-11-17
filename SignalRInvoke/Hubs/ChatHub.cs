using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;

namespace SignalRInvoke.Hubs
{
    public class ChatHub : Hub
    {
       public async Task InvokeMessage(string user, string message)
       {
          Console.WriteLine("Hub.InvokeMessage: method entry.");
          // System.Exception thrown here after the client returned bool value.
          bool result = await Clients.Caller.InvokeAsync<bool>(
             "ReceiveMessageInvoke", user, message, CancellationToken.None);
          Console.WriteLine($"Hub.InvokeMessage: method exit. result: {result}.");
       }
    }
}
