using StoneEmployee.Core.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StoneEmployee.Core.Entities
{
    public class PayslipItem
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PayslipItemType Type { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
    }
}
