using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestSharpDZ
{
    public class MoneyJSON
    {

            [JsonPropertyName("exchangedate")]
            public string Exchangedate { get; set; }

            [JsonPropertyName("rate")]
            public double Rate { get; set; }

        public MoneyJSON(string exchangedate, double rate)
        {
            Exchangedate = exchangedate;
            Rate = rate;
        }
        public override string ToString()
            {
                return $"{Exchangedate} = {Rate}";
            }

        
    }
}
