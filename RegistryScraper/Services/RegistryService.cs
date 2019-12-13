using Newtonsoft.Json;
using RegistryScraper.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistryScraper.Services
{
    public class RegistryService
    {
        public static List<TargetItem> GetTargetItems()
        {
            //Refactor to pull from config file.
            string registryURL = "https://api.target.com/registry_items_availabilities/v2/giftgiver/3a92afc801324e298104fbac638f4f02/2799?channel_name=web&key=a85fa3a4f72483a59c54a7ac8c223fa4d16588c7&sn_id=95843810";
            
            var client = new RestClient(registryURL);
            var request = new RestRequest()
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json,
            };

            try
            {
                var response = client.Execute(request);
                var targetResponse = JsonConvert.DeserializeObject<TargetResponse>(response.Content);

                return new List<TargetItem>(targetResponse.registries.items);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public static List<AmazonItem> GetAmazonItems()
        {  
            try
            {
                int page = 1;
                List<AmazonItem> amazonItems = new List<AmazonItem>();
                AmazonResponse amazonResponse = new AmazonResponse();

                do
                {
                    amazonResponse = SendAmazonRequest(page);
                    amazonItems.AddRange(amazonResponse.result.minimalRegistryItems);
                    page++;
                } while (amazonResponse.result.filteredItemTotal > amazonItems.Count);

                return amazonItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private static AmazonResponse SendAmazonRequest(int page)
        {
            string registryURL = "https://www.amazon.com/wedding/items/3UGQ2T0I1KVOJ";

            var client = new RestClient(registryURL);
            var request = new RestRequest()
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json,
            };

            request.AddQueryParameter("page", page.ToString());

            var response = client.Execute(request);
            var amazonResponse = JsonConvert.DeserializeObject<AmazonResponse>(response.Content);

            if (amazonResponse.success)
                return amazonResponse;
            else
                throw new Exception("Call to amazon falied. Reason: " + amazonResponse.errorMessage);
        }

    }
}
