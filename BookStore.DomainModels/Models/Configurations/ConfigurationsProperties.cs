using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DomainModels.Models.Constants
{
    public class ConfigurationsProperties
    {
        public string AppName { get; set; }
        public string ConnectionString { get; set; }
        public string CoverImagePath { get; set; }
        public string GalleryImagesPath { get; set; }
    }
}
