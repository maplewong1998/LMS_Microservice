using IdentityModel;
using IdentityModel.Client;
using LMS.Client.ApiServices;
using LMS.Client.HttpHandlers;
using LMS.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Movies.Client.HttpHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client
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
            services.AddMvc();

            services.AddScoped<IUserApiService, UserApiService>();

            services.AddScoped<IBookApiService, BookApiService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = "https://localhost:5021";

                    options.ClientId = "LMSClientWithIdentity";
                    options.ClientSecret = "secret";

                    options.ResponseType = "code id_token";

                    options.Scope.Add("openid");
                    options.Scope.Add("name");
                    options.Scope.Add("profile");
                    options.Scope.Add("email");
                    options.Scope.Add("bookAPI");
                    options.Scope.Add("userManagerAPI");
                    options.Scope.Add("username");
                    options.Scope.Add("role");
                    options.Scope.Add("account_status");

                    options.ClaimActions.MapUniqueJsonKey("name", "name");
                    options.ClaimActions.MapUniqueJsonKey("username", "username");
                    options.ClaimActions.MapUniqueJsonKey("role", "role");
                    options.ClaimActions.MapUniqueJsonKey("account_status", "account_status");

                    options.SaveTokens = true;

                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = JwtClaimTypes.Role
                    };
                });

            services.AddTransient<DefaultDelegatingHandler>();

            services.AddTransient<AuthenticationDelegatingHandler>();
            

            services.AddHttpClient("DefaultOcelotAPIGateway", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5031/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).AddHttpMessageHandler<DefaultDelegatingHandler>();

            services.AddHttpClient("DefaultIDPClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5021/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            services.AddHttpClient("AuthenticatedOcelotAPIGateway", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5031/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

            services.AddHttpClient("AuthenticatedIDPClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5021/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

            services.AddSingleton(new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:5021/connect/token",
                ClientId = "LMSClient",
                ClientSecret = "secret",
                Scope = "bookAPI userManagerAPI"
            });

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
