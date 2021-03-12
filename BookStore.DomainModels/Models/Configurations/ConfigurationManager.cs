using BookStore.DomainModels.Models.Constants;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DomainModels.Models.Configurations
{
    public static class ConfigurationManager
    {
        public static IOptions<ConfigurationsProperties> _appConfig { get; set; }

        public static string ConnectionString { get { return _appConfig.Value.ConnectionString; } }
        public static string CoverImagePath { get { return _appConfig.Value.CoverImagePath; } }
        public static string GalleryImagesPath { get { return _appConfig.Value.GalleryImagesPath; } }
    }
}
