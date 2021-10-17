using System;
using System.Linq;
using System.Net.Http;
using Abernathy.Assessement.Service.Services;
using Abernathy.Assessement.Service.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;

namespace Abernathy.Assessement.Service
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

            // service Layer

            services.AddTransient<IAssessementService, AssessementService>();
            services.AddTransient<IExternalDemographicsService, ExternalDemograhicsService>();
            services.AddTransient<IExternalHistoryService, ExternalHistoryService>();

            // microservices

            services.AddHttpClient<IExternalDemographicsService, ExternalDemograhicsService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["DemographicsMicroservice:Url"]);
            }).AddPolicyHandler(GetRetryPolicy());

            services.AddHttpClient<IExternalHistoryService, ExternalHistoryService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["HistoryMicroservice:Url"]);
            }).AddPolicyHandler(GetRetryPolicy());

            // controller layer

            services.AddControllers(options => {
                var noContentFormatter =
                    options.OutputFormatters.OfType<HttpNoContentOutputFormatter>().FirstOrDefault();

                if (noContentFormatter != null)
                {
                    noContentFormatter.TreatNullValueAsNoContent = false;
                }
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Abernathy.Assessement.Service", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Abernathy.Assessement.Service v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
              // Handle HttpRequestExceptions, 408 and 5xx status codes
              .HandleTransientHttpError()
              // Handle 404 not found
              .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
              // Handle 401 Unauthorized
              .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.Unauthorized)
              // What to do if any of the above erros occur:
              // Retry 3 times, each time wait 1,2 and 4 seconds before retrying.
              .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
