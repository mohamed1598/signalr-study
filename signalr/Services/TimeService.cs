﻿
using Microsoft.AspNetCore.SignalR;
using signalr.Hubs;
using System.Threading;

namespace signalr.Services
{
    public class TimeService : IHostedService, IDisposable
    {
        private readonly IHubContext<TimeHub> _timeHub;
        private Timer _timer;
        public TimeService(IHubContext<TimeHub> timeHub)
        {
            _timeHub = timeHub;
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
        private void Tick(object state)
        {
            var currentTime = DateTime.UtcNow.ToString("F");
            _timeHub.Clients.All.SendAsync("updateCurrentTime", currentTime);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Tick, null, 0, 500);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
