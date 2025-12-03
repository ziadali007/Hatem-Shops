
using Apple1_Domain.Contracts;
using Apple1_Services;
using Apple1_Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presistence.Data;
using Presistence.Repositories;
using Quartz;
using System.Reflection;
namespace Apple1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<Apple1DbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IArchiveDailySalesService, ArchiveDailySalesService>();
            builder.Services.Configure<AdminSettings>(
              builder.Configuration.GetSection("AdminSettings"));



            builder.Services.AddAutoMapper(cfg =>
            {
                // This explicitly uses the overload that takes a configuration action.
                // Inside the action, AddMaps is called with the assemblies.
                // This is the most unambiguous way to tell AutoMapper to scan the assemblies.
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });





            builder.Services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                var jobKey = new JobKey("DailySalesArchiveJob");

                q.AddJob<DailySalesQuartzJob>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("DailySalesArchiveTrigger")
                    .WithCronSchedule("0 59 23 * * ?"));  // runs every day at 23:59
            });

            builder.Services.AddQuartzHostedService();




            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
