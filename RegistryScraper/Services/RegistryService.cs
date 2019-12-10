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
        public static TargetItem[] GetTargetItems()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.target.com");

            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = "/registry_items_availabilities/v2/giftgiver/3a92afc801324e298104fbac638f4f02/2799?channel_name=web&key=a85fa3a4f72483a59c54a7ac8c223fa4d16588c7&sn_id=95843810",
                RequestFormat = DataFormat.Json,
            };

            try
            {
                var response = client.Execute(request);
                var targetResponse = JsonConvert.DeserializeObject<TargetResponse>(response.Content);

                foreach (var item in targetResponse.registries.items)
                {
                    Console.WriteLine(item.title + " " + item.price);
                }
                return null;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}
