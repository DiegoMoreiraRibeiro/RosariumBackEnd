using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RosariumBackEnd.Domain.Interfaces;
using RosariumBackEnd.Domain.Repository;
using RosariumBackEnd.Entities.Entities;
using RosariumBackEnd.Service.Interfaces;
using RosariumBackEnd.Service.Services;
using RosariumBackEnd.Service.Utils;

namespace RosariumBackEnd.Infra.IoC
{
    public static class InitIOC
    {
        public static ServiceProvider InitIOC_Schedule<T>(ServiceCollection services, string connectionStrig) where T : class
        {
            InitDB(services, connectionStrig);
            InitUtils(services);
            InitCore<T>(services);
            return services.BuildServiceProvider();
        }

        public static ServiceProvider InitIOC_Api(IServiceCollection services, string connectionStrig)
        {
            InitDB(services, connectionStrig);
            InitUtils(services);
            InitCore(services);
            return services.BuildServiceProvider();
        }


        public static void InitDB(IServiceCollection services, string connectionStrig)
        {
            services.AddDbContext<MyApplicationDbContext>(options =>
                options.UseSqlServer(connectionStrig));

        }

        public static void InitUtils(IServiceCollection services)
        {
            services.AddScoped<ObjectMapper>();
            services.AddHttpClient();
        }

        public static void InitCore<T>(IServiceCollection services) where T : class
        {
            services.AddScoped<T>();

            services.AddScoped<ICustomHttpUtils, CustomHttpUtils>();

            services.AddScoped<IEvangelhoRepository, EvangelhoRepository>();
            services.AddScoped<IEvangelhoService, EvangelhoService>();

            services.AddScoped<ILiturgiaService, LiturgiaService>();
            services.AddScoped<ILiturgiaRepository, LiturgiaRepository>();
        }

        public static void InitCore(IServiceCollection services)
        {
            services.AddScoped<ICustomHttpUtils, CustomHttpUtils>();

            services.AddScoped<IEvangelhoRepository, EvangelhoRepository>();
            services.AddScoped<IEvangelhoService, EvangelhoService>();

            services.AddScoped<ILiturgiaService, LiturgiaService>();
            services.AddScoped<ILiturgiaRepository, LiturgiaRepository>();
        }
    }
}