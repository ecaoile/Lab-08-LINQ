using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab_08_LINQ.Classes
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FeaturesCollection
    {
        [JsonProperty]
        public List<Features> Features { get; set; }
        public string Type { get; set; }
        //[JsonProperty]
        //public List<Properties> Properties { get; set; }

    }
}
