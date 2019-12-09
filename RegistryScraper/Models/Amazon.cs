using System;

namespace RegistryScraper.Models
{
    public class AmazonResponse
    {
        public bool success { get; set; }
        public string errorMessage { get; set; }
        public string errorCode { get; set; }
        public AmazonResult result { get; set; }
        public int filteredItemTotal { get; set; }
    }

    public class AmazonResult
    {
        public AmazonItem[] minimalRegistryItems { get; set;}
        public int filteredItemTotal { get; set; }
    }

    public class AmazonItem
    {
        public string itemId { get; set; }
        public string legacyItemId { get; set; }
        public int qtyRequested { get; set; }
        public int qtyPurchased { get; set; }
        public int qtyNeeded { get; set; }
        public string imageURL { get; set; }
        public string productUrl { get; set; }
        public string productTitle { get; set; }
        public AmazonPrice itemPrice { get; set; }
        public bool mustHave { get; set; }

    }

    public class AmazonPrice
    {
        public int amount { get; set; }
        public string displayString { get; set; }
    }
}
