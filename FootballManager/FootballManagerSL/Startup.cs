using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FootballManagerBL.DAL;
using Microsoft.EntityFrameworkCore;
using FootballManagerBL.Interfaces;
using FootballManagerBL.Model;

namespace FootballManagerSL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<DbContext, EFContext>();

            //services.AddTransient<IRepository<Player, Guid>, EFRepository<Player, Guid>>();
            //services.AddTransient<IRepository<Team, Guid>, EFRepository<Team, Guid>>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //var connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст EFContext в качестве сервиса в приложение


            //services.AddDbContext<EFContext>(options =>
            //    options.UseSqlServer(connection));

            services.AddMvc();

            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            app.UseMvc();
        }
    }
}
