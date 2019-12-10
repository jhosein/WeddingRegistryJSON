using System;
using System.Collections.Generic;
using System.Text;

namespace RegistryScraper.Models
{
    public class HoseinRegistryItem
    {
        public string productID { get; set; }
        public string storeName { get; set; }
        public string productTitle { get; set; }
        public string priceDisplayString { get; set; }
        public decimal priceRaw { get; set; }
        public string imageURL { get; set; }
        public string productURL { get; set; }
        public int qtyRequested { get; set; }
        public int qtyPurchased { get; set; }
        public int qtyNeeded { get; set; }
        public bool isFavorite { get; set; }
        public List<ConversionTag> tags { get; set; }

    }

    public class ConversionTag
    {
        public string name { get; set; }
        public string colorHex { get; set; }
    }
}

