using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nameProject.webApi.models
{
    public class ProductAssurence
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int price { get; set; }

        public string CampaignStartDate { get; set; }

        public string CampaignEndDate { get; set; }
    }
}