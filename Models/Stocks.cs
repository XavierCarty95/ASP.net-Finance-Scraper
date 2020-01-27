using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Portfolio.Models
{
    public class Stocks
    {

        public int ID { get; set; }
        public string Symbol { get; set; }
        public string LastPrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]

        [DataMember]
        public DateTime? DateScrapped { get; set; }
        public string Change { get; set; }
        public string ChangeRate { get; set; }
        public string Currency { get; set; }
        public string MarketTime { get; set; }
        public string Volume { get; set; }
        public string ShareData { get; set; }
        public string AverageVolume { get; set; }
        public string MarketCapData { get; set; }



    }
}
