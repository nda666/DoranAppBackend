using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dotmim.Sync;
using Dotmim.Sync.Enumerations;
using Dotmim.Sync.MySql;
using Dotmim.Sync.SqlServer;
using Dotmim.Sync.Web.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DoranOfficeBackend.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DoranOfficeBackend.Middleware;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using DoranOfficeBackend.Dto.User;
using Microsoft.IdentityModel.Logging;

namespace DoranOfficeBackend
{

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DoranDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });


            //services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

            //});

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerFromQuery>();

            });

            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {

                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(Configuration.GetSection("Jwt")["Secret"])),
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


            services.AddDistributedMemoryCache();
            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));


            // [Required]: Get a connection string to your server data source
            // var connectionString = Configuration.GetSection("ConnectionStrings")["SqlConnection"];
            var connectionString = "server=localhost;uid=root;pwd=;database=doran-office";

            var options = new SyncOptions
            {
                SnapshotsDirectory = "C:\\Tmp\\Snapshots",
                BatchSize = 2000,
            };

            // [Required] Tables involved in the sync process:
            var tables = new string[] { "users", "roles" };

            // [Required]: Add a SqlSyncProvider acting as the server hub.
            services.AddSyncServer<MySqlSyncProvider>(connectionString, tables, options);



            //services.AddFluentValidationAutoValidation();
            //services.AddScoped<IValidator<SalesChannel>, SalesChannelValidator>();
            //services.AddScoped<IValidator<User>, UserValidator>();
            //services.AddScoped<IValidator<Role>, RoleValidator>();
            //services.AddScoped<IValidator<SalesChannel>, SalesChannelValidator>();
            //services.AddScoped<IValidator<SalesTeam>, SalesTeamValidator>();
            //services.AddScoped<IValidator<Sales>, SalesValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseSession();

            app.UseMiddleware<JwtMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());


            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.MapRazorPages();

            //app.Run();
        }
    }
}