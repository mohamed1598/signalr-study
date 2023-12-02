using Microsoft.AspNetCore.SignalR;
using static signalr.Hubs.ViewHub;

namespace signalr.Hubs
{
    public class ViewHub:Hub<IHubClient>
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
            //return Clients.All.SendAsync("ViewCountUpdate", ViewCount);
            return Clients.All.ViewCountUpdate(ViewCount);
        }
        public async override Task OnConnectedAsync()
        {
            ViewCount++;

            await this.Clients.All.ViewCountUpdate(ViewCount); ;

            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            ViewCount--;

            await this.Clients.All.ViewCountUpdate(ViewCount); ;

            await base.OnDisconnectedAsync(exception);
        }
        public interface IHubClient
        {
            Task ViewCountUpdate(int viewCount);
        }
    }
}
