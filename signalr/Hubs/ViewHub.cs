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
        public async override Task OnConnectedAsync()
        {
            ViewCount++;

            await this.Clients.All.SendAsync("viewCountUpdate", ViewCount);

            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            ViewCount--;

            await this.Clients.All.SendAsync("viewCountUpdate", ViewCount);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
