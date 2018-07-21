using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crayons.Domain.DataAccess;
using Crayons.Domain.DataAccess.Repositories;
using Crayons.Domain.DataAccess.Repositories.Interfaces;
using Crayons.Domain.Entities;
using Crayons.Infrastructure.Services;
using Crayons.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crayons.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<CrayonsDbContext>(dbOptions => 
                dbOptions.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            services.AddScoped<IRepository<Recipe>,Repository<Recipe>>();
            services.AddScoped<IRecipiesService,RecipiesService>();
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
