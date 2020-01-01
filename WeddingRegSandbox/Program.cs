using RegistryScraper.Services;
using System;
using RegistryScraper.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WeddingRegSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start...");
            var now = DateTime.UtcNow;

            Console.ReadLine();

            List<HoseinProduct> products = new List<HoseinProduct>();
            var amazonItems = RegistryService.GetAmazonItems();
            var targetItems = RegistryService.GetTargetItems();

            products.AddRange(ProductService.Standardize(targetItems));
            products.AddRange(ProductService.Standardize(amazonItems));

            using (StreamWriter file = File.CreateText("products.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, products);
            }

        }
    }
}
