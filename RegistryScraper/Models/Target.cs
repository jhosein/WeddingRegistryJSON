using System;
using System.Collections.Generic;
using System.Text;

namespace RegistryScraper.Models
{
    public class TargetResponse
    {
        public TargetRegistry registries { get; set; }

    }

    public class TargetRegistry
    {
        public int item_count { get; set; }
        public TargetItem[] items { get; set; }

    }

    public class TargetItem
    {
        public string tcin { get; set; }
        public string barcode { get; set; }
        public string most_wanted_flag { get; set; }
        public int requested_quantity { get; set; }
        public int purchased_quantity { get; set; }
        public string title { get; set; }
        public TargetImage images {get; set;}
        public TargetPrice price { get; set; }
        public string target_dot_com_uri { get; set; }
    }

    public class TargetImage
    {
        public string primaryUri { get; set; }
    }

    public class TargetPrice
    {
        string formatted_current_price { get; set; }
        string formatted_current_price_type { get; set; }
        bool default_price { get; set; }
        int save_percent { get; set; }
        int save_dollar { get; set; }
    }

    public class TargetOnlineInfo
    {
        string freeShipping { get; set; }
    }
}
