using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.WebAPI.Core.DTO
{
    public class StatisticDTO
    {
        public int Id { get; set; }
        public string DescriptionInfo { get; set; }
        public int Clicks { get; set; }
        public int Expend { get; set; }
        public int Price { get; set; }
        public int PriceClient { get; set; }
        public int Conversion { get; set; }
      
    }
}
