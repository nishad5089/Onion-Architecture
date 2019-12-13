using System.Net.Http;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Onion.API;
using System.Threading.Tasks;
using Onion.Infrastructure.Context;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace Onion.Test
{
    public class UnitTest1
    {

      public IConfiguration Configuration { get; }

     private readonly HttpClient _client;
        public UnitTest1()
        {
            var appFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
                    {
                        builder.ConfigureServices(services =>
                        {
                            services.RemoveAll(typeof(ApplicationDbContext));
                            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("OnionDBConnection")));
                        });
                    });;
            _client = appFactory.CreateClient();
        }
        [Fact]
        public async Task Test1()
        {
           var request = new
            {
                Url = "/api/student",
                Body = new
                {
                    name = "Nishad"
                }
            };
            var response =  await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }
         [Fact]
        public async Task Get()
        {
           
            var response =  await _client.GetAsync("/api/student");
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }

     public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }
}
