using Microsoft.AspNetCore.SignalR;

namespace signalr.Hubs
{
    public class StringToolsHub:Hub
    {
        public string GetFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
    }
}
