using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Hosting;
using Scope.Services;

namespace Scope.Jobs
{
    class MyJob : BackgroundService
    {
        readonly TransientService transientService;
        readonly ScopeService scopeService;
        readonly SingletonService singletonService;

        public MyJob(
            TransientService transientService,
            // System.InvalidOperationException: Cannot consume scoped service 'Scope.Services.ScopeService' from singleton 'Microsoft.AspNetCore.Hosting.Internal.HostedServiceExecutor'
//            ScopeService scopeService,
            SingletonService singletonService)
        {
            this.transientService = transientService;
//            this.scopeService = scopeService;
            this.singletonService = singletonService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {

              Console.WriteLine($">> transientService: {transientService.GetHashCode()}");
  //            Console.WriteLine($">> scopeService: {scopeService.GetHashCode()}");
              Console.WriteLine($">> singletonService: {singletonService.GetHashCode()}");

              Thread.Sleep(TimeSpan.FromSeconds(3));
            }

            return Task.CompletedTask;
        }
    }
}
