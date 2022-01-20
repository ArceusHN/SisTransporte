using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace SisTransporte
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(configure =>
                {
                    configure.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<dbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"));
            });

            services.AddScoped<IViajeRepositoryAsync, ViajesRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
