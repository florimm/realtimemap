﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Proto;
using Proto.Cluster;

namespace Backend
{
    public class ActorSystemHostedService : IHostedService
    {
        private readonly ActorSystem _actorSystem;

        public ActorSystemHostedService(ActorSystem actorSystem)
        {
            _actorSystem = actorSystem;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _actorSystem
                .Cluster()
                .StartMemberAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _actorSystem
                .Cluster()
                .ShutdownAsync();
        }
    }
}