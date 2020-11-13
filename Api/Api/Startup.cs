namespace Avanssur.AxaDeveloperDashboard.Api
{
    using System;

    using Autofac;

    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector.Autofac;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector.MySql;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddAuthorization()
                .AddControllers()
                .AddNewtonsoftJson();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<Logic.LogicModule>();
            builder.WithMySqlPersistence("AxaDashboard", name => this.Configuration.GetConnectionString(name));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            var allowedOriginsSection = this.Configuration.GetSection("AllowedOrigins");
            var origins = allowedOriginsSection.Value.Split(";", StringSplitOptions.RemoveEmptyEntries);
            app.UseCors(builder => builder
                .WithOrigins(origins)
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
