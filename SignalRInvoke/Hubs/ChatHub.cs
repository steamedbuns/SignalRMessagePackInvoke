using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;

namespace SignalRInvoke.Hubs
{
    public class ChatHub : Hub
    {
       public async Task InvokeMessage(string user, string message)
       {
          Console.WriteLine("Hub.InvokeMessage: method entry.");
          Stopwatch timer = new();
          timer.Restart();
          bool result = await Clients.Caller.InvokeAsync<bool>(
             "ReceiveMessageInvoke", user, message, CancellationToken.None);
          timer.Stop();
          var ms = timer.ElapsedMilliseconds;
          Console.WriteLine($"Hub.InvokeMessage: method exit. result: {result}, time: {ms}");
       }
    }
}
