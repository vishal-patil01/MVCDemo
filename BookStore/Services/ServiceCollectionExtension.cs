﻿using BookStore.BussinessLayer.Implementation;
using BookStore.BussinessLayer.Interface;
using BookStore.DataAccessLayer.Implementation;
using BookStore.DataAccessLayer.Interface;
using BookStore.DomainModels.Models.Configurations;
using BookStore.DomainModels.Models.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection SetupDependancy(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConfigurationsProperties>(configuration.GetSection("Configurations"));
            ConfigurationManager._appConfig = services.BuildServiceProvider().GetService<IOptions<ConfigurationsProperties>>();
            services.AddTransient<IBookstoreRepository, BookstoreRepository>();
            services.AddTransient<IBookstoreService, BookstoreService>();
            return services;
        }
    }
}
