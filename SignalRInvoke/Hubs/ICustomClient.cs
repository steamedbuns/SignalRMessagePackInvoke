namespace SignalRInvoke.Hubs
{
    public interface ICustomClient
    {
       Task<bool> ReceiveMessageInvoke(string user, string message);
    }
}
