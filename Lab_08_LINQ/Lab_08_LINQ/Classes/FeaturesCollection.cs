using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab_08_LINQ.Classes
{
    /// <summary>
    /// top level class containing a list of Features objects and a string
    /// </summary>
    public class FeaturesCollection
    {
        [JsonProperty]
        public List<Features> Features { get; set; }
        public string Type { get; set; }
    }
}
