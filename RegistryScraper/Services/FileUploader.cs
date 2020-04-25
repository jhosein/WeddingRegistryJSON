using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using RegistryScraper.Models;
using Newtonsoft.Json;

namespace RegistryScraper.Services
{
    public static class FileUploader
    {
        public static void UploadProducts(List<HoseinProduct> products)
        {
            var jsonProducts = JsonConvert.SerializeObject(products);
            var stream = GenerateStreamFromJSON(jsonProducts);

            Console.WriteLine("Await");
            const string bucketName = "";
            const string keyName = "";
            const string filePath = "";

            RegionEndpoint bucketRegion = RegionEndpoint.USEast1;//change later
            IAmazonS3 s3Client;

            s3Client = new AmazonS3Client(bucketRegion);
            

        }

        public static Stream GenerateStreamFromJSON(string json)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(json);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static void doUpload()
        {

        }
    }
}
