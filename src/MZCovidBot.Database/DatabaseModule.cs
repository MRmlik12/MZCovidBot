using System;
using Autofac;
using MZCovidBot.Database.Interfaces;
using MZCovidBot.Database.Repositories;
using Module = Autofac.Module;

namespace MZCovidBot.Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>()
                .WithParameter("connectionString", Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? string.Empty)
                .InstancePerLifetimeScope();
            
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<CovidDataRepository>()
                .As<ICovidDataRepository>()
                .InstancePerLifetimeScope();
        }
    }
}