
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.Dependency.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using System.Globalization;

namespace TravelAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //IoC Container => mapper, autofac Dependence Resolve
            //builder.Services.AddSingleton<ITourService, TourManager>();
            //builder.Services.AddSingleton<ITourDal, EfTourDal>();
            //builder.Services.AddSingleton<IGuideService, GuideManager>();
            //builder.Services.AddSingleton<IGuideDal, EfGuideDal>();
            //builder.Services.AddSingleton<ICustomerService, CustomerManager>();
            //builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule<AutofacBusinessModule>();
            });

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
