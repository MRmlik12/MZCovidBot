using System;
using Quartz;
using Quartz.Spi;

namespace MZCovidBot.Jobs
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceProvider _services;

        public JobFactory(IServiceProvider services)
        {
            _services = services;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _services.GetService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}