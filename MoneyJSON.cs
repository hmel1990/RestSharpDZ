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

        [JsonPropertyName("txt")]
        public string Txt { get; set; }

        public MoneyJSON(string exchangedate, double rate, string currency)
        {
            Exchangedate = exchangedate;
            Rate = rate;
            Txt = currency;
        }
        public override string ToString()
            {
                return $"курс {Txt} к гривне на {Exchangedate} = {Rate}";
            }

        
    }
}
