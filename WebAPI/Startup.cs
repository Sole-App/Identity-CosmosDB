using AutoMapper;
using ElCamino.AspNetCore.Identity.CosmosDB.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Munizoft.Identity.Infrastructure.Models;
using Munizoft.Identity.Infrastructure.Services;
using Newtonsoft.Json.Serialization;
using Sole.Identity.CosmosDB.Core.Persistence;

namespace Sole.Identity.CosmosDB
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
            services
                .AddIdentityCore<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.SignIn.RequireConfirmedEmail = true;

                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;

                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                })
                .AddCosmosDBStores<IdentityContext>(() =>
                {
                    return new IdentityConfiguration()
                    {
                        Uri = Configuration["IdentityCosmosDB:Uri"],
                        AuthKey = Configuration["IdentityCosmosDB:AuthKey"],
                        Database = Configuration["IdentityCosmosDB:Database"],
                        IdentityCollection = Configuration["IdentityCosmosDB:Collection"],
                        Options = new CosmosClientOptions()
                        {
                            ConnectionMode = ConnectionMode.Gateway,
                            ConsistencyLevel = ConsistencyLevel.Session,
                            SerializerOptions = new CosmosSerializationOptions()
                            {
                                IgnoreNullValues = true,
                                Indented = false,
                                PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                            }
                        }
                    };
                })
                .CreateCosmosDBIfNotExists<IdentityContext>(); //can remove after first run;

            services.AddOptions<IdentityOptions>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddAutoMapper(typeof(UserService));

            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sole.Identity.CosmosDB", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sole.Identity.CosmosDB v1"));
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
