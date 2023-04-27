

using DataAcces.Concrete.EntityFramework;
using DataAccess;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace WorkerService
{
    namespace WorkerService
    {
        public class Worker : BackgroundService
        {
            private readonly ILogger<Worker> _logger;

            public Worker()
            {
            }

            public Worker(ILogger<Worker> logger)
            {

                _logger = logger;
            }


            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);

                    PerformanceCounter cpuCounter, ramCounter;
                    cpuCounter = new PerformanceCounter();
                    cpuCounter.CategoryName = "Processor";
                    cpuCounter.CounterName = "% Processor Time";
                    cpuCounter.InstanceName = "_Total";
                    int name, ort = 0;
                    ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
                    int temp = 0, ortm = 0;
                    name = Convert.ToInt32(cpuCounter.NextValue());
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(3000);
                        name = Convert.ToInt32(cpuCounter.NextValue());
                        ort += name;
                        temp = Convert.ToInt32(ramCounter.NextValue());
                        ortm += temp;


                    }
                    ortm = ortm / 100;
                    ort = ort / 10;

                    DateTime date = DateTime.Now;

                    using (var context = new SimpleContextDb())
                    {
                        User user = new User();
                        user.Date = date;
                        user.ram = ortm;
                        user.Cpu = ort;
                        context.Add(user);
                        context.SaveChanges();


                    }

                }
            }
        }
    }
}

