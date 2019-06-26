using AutoMapper;
using ContactManager.API.ConfigurationMapper;
using ContactManager.Shared.InjectionDependencies.CommandsDependency;
using ContactManager.Shared.InjectionDependencies.ContextDependency;
using ContactManager.Shared.InjectionDependencies.FacadeDepedency;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            CommandsInjection.RegisterService(services);
            ContextInjection.RegisterService(services);
            FacadeInjection.RegisterService(services);

            Mapper.Initialize(cfg => cfg.AddProfile<MapperConfig>());

            services.AddMvc(options =>
                options.CacheProfiles.Add("Default30", new CacheProfile() { Duration = 30 })
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
