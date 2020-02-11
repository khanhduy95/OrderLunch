﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fetch.OrderLunch.Infrastructure.Data;
using Fetch.OrderLunch.WebApi.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Fetch.OrderLunch.WebApi
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                    .Build();
                host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        
    }
}
