using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartStore.Web.Models.Catalog
{
    public class ImageSlider
    {
        public int Id { get; set; }
        public string IName { get; set; }
        public string FilePath { get; set; }
        public byte[] Image { get; set; }
        public string MobileImageFilePath { get; set; }
        public byte[] MobileImage { get; set; }
    }
}