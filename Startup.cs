using CMSByTeamJava.Models;
using CMSByTeamJava.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSByTeamJava
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
            services.AddControllers();
            services.AddDbContext<CLINIC_DBContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DevelopConnection")));
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IStaffRepository, StaffsRepository>();
            services.AddScoped<IPharmacistRepository, pharmacistsRepository>();
            services.AddScoped<IPatientsRepository, PatientsRepository>();
            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            services.AddScoped<IDoctorsRepository, DoctorsRepository>();


            services.AddControllers().AddNewtonsoftJson(
                options =>
                {
                    //enables text json - display exact match
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                    //enables to avoid infinte loop - Recursive
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });




            //Enable cors
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }




            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

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
