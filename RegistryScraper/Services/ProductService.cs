using System;
using System.Collections.Generic;
using System.Text;
using RegistryScraper.Models;

namespace RegistryScraper.Services
{
    public static class ProductService
    {
        /// <summary>
        /// Maps Target.com items to the HoseinProduct  model.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<HoseinProduct> Standardize(List<TargetItem> items)
        {
            var products = new List<HoseinProduct>();

            foreach (var targetItem in items)
            {
                var product = new HoseinProduct()
                {
                    storeCode = (int) StoreCode.Target,
                    storeDisplayString = "Target.com",
                    productID = targetItem.barcode,
                    productTitle = targetItem.title,
                    priceDisplayString = targetItem.price.formatted_current_price,
                    priceReg = targetItem.price.reg_retail,
                    priceCurrent = targetItem.price.current_retail,
                    imageURL = targetItem.images.primaryUri,
                    productURL = targetItem.target_dot_com_uri,
                    qtyRequested = targetItem.requested_quantity,
                    qtyNeeded = targetItem.requested_quantity - targetItem.purchased_quantity,
                    isFavorite = targetItem.most_wanted_flag == "N" ? false : true,
                };

                product.tags = CreateTags(targetItem);
                products.Add(product);
            }

            return products;
        }

        private static List<ConversionTag> CreateTags (TargetItem targetItem)
        {
            var tags = new List<ConversionTag>();

            //Free Shipping
            if (targetItem.online_info.freeShipping)
                tags.Add(new ConversionTag { name = "Free Shipping", colorHex = ConversionHex.FreeShipping });

            //Sale
            if (targetItem.price.reg_retail > targetItem.price.current_retail)
            {
                //Save $xx.xx
                if (targetItem.price.save_dollar > targetItem.price.save_percent && targetItem.price.save_dollar != 0)
                    tags.Add(new ConversionTag { name = "SAVE " + targetItem.price.save_dollar.ToString("C"), colorHex = ConversionHex.Sale });
                //xx% off
                else if (targetItem.price.save_dollar < targetItem.price.save_percent && targetItem.price.save_percent != 0)
                    tags.Add(new ConversionTag { name = targetItem.price.save_percent.ToString() + "% off", colorHex = ConversionHex.Sale });
            }

            return tags;
        }

        public enum StoreCode : int
        {
            Target = 100,
            Amazon = 200
        }

        public static class ConversionHex 
        {
            //TODO
            public static string Sale = "";
            public static string FreeShipping = "";
            public static string MustHave = "";
        }
    }
}
