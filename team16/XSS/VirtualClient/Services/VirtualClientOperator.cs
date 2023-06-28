using Microsoft.Extensions.Options;
using PlaywrightClient.Models;

namespace PlaywrightClient.Services
{
    public class VirtualClientOperator : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public VirtualClientOperator(IServiceScopeFactory scopeFactory)
        { 
            _scopeFactory = scopeFactory;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
#pragma warning disable CS4014
            ExecuteAsync(cancellationToken);
#pragma warning restore CS4014
            return Task.CompletedTask;
        }

        private async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateAsyncScope())
                {
                    var client = scope.ServiceProvider.GetService<IVirtualClient>();
                    var settings = scope.ServiceProvider.GetService<IOptions<VirtualClientOptions>>();


                    await client!.RunClientAsync();

                    await Task.Delay(settings!.Value.VisitFrequency * 1000, cancellationToken);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
