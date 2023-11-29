using Microsoft.AspNetCore.SignalR;

namespace signalr.Hubs
{
    public class ViewHub:Hub
    {
        public static int ViewCount { get; set; } = 0;

        //public async Task NotifyWatching()
        //{
        //    ViewCount++;

        //    // notify everyone about new view count
        //    await Clients.All.SendAsync("ViewCountUpdate", ViewCount);
        //}
        public Task NotifyWatching()
        {
            ViewCount++;

            // notify everyone about new view count
            return Clients.All.SendAsync("ViewCountUpdate", ViewCount);
        }
    }
}
