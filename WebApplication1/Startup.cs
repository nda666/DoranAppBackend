using Dotmim.Sync;
using Dotmim.Sync.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DoranOfficeBackend.Middleware;
using MySql.EntityFrameworkCore.Extensions;
using DoranOfficeBackend.Interceptors;
using DoranOfficeBackend.Mappings;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.ReDoc;

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
               
                options.AddInterceptors(new TimestampInterceptor()).UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(
                typeof(Startup), 
                typeof(MasterTimSalesMapping),
                typeof(SalesMapping),
                typeof(HkategoribarangMapping)
                );

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
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Doran Office Backend",
                    Description = "API DOCS - Doran Office Backend",
                    Contact = new OpenApiContact()
                    {
                        Name = "Adha Bakhtiar (Developer ☠️)",
                        Url = new Uri("https://github.com/nda666"),
                        Email = "adhabakhtiar@gmail.com"
                    },
                });
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
            var connectionString = Configuration.GetSection("ConnectionStrings")["DefaultConnection"];

            var options = new SyncOptions
            {
                BatchSize = 2000,
            };

            // [Required] Tables involved in the sync process:
            var tables = new string[] { "masterchannelsales" };

            // [Required]: Add a SqlSyncProvider acting as the server hub.
            services.AddSyncServer<MySqlSyncProvider>(
                connectionString:connectionString,
                tables: tables, 
                options: options,
                scopeName: "v2"
                );

           

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
                app.UseSwagger(c =>
                {
                    c.SerializeAsV2 = true;
                });
                app.UseReDoc(c =>
                {
                    c.RoutePrefix = "docs";
                    c.SpecUrl("/swagger/v1/swagger.json");
                });
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