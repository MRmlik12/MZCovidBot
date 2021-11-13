using System;
using System.Threading.Tasks;
using MZCovidBot.Jobs;
using Quartz;

namespace MZCovidBot
{
    public class Scheduler
    {
        private readonly IServiceProvider _services;
        private IScheduler _scheduler;

        public Scheduler(IServiceProvider services)
        {
            _services = services;
        }

        private async Task StartScheduler()
        {
            _scheduler = await SchedulerBuilder.Create()
                .UseDefaultThreadPool(x => x.MaxConcurrency = 5)
                .UseInMemoryStore()
                .BuildScheduler();

            await _scheduler.Start();
        }

        private async Task InitializeJobs()
        {
            _scheduler.JobFactory = new JobFactory(_services);
            var covidJob = JobBuilder.Create<SendCovidStatJob>()
                .WithIdentity("covid-job", "covid-group")
                .Build();
            var covidTrigger = TriggerBuilder.Create()
                .WithIdentity("covid-trigger", "covid-group")
                .StartAt(DateTimeOffset.Now)
                .WithSimpleSchedule(x => x.WithIntervalInMinutes(30).RepeatForever())
                .Build();

            await _scheduler.ScheduleJob(covidJob, covidTrigger);
        }

        public async Task Setup()
        {
            await StartScheduler();
            await InitializeJobs();
        }
    }
}