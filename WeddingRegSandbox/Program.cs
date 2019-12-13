using RegistryScraper.Services;
using System;

namespace WeddingRegSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start...");
            Console.ReadLine();

            var amazonItems = RegistryService.GetAmazonItems();
            var targetItems = RegistryService.GetTargetItems();


        }
    }
}
