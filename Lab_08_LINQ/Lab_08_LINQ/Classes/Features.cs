using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_08_LINQ.Classes
{
    /// <summary>
    /// class containing a string Type, Geometry object, and Properties object
    /// </summary>
    public class Features
    {
        public string Type { get; set; }
        public Geometry Geometry {get; set;}
        public Properties Properties { get; set; }
    }
}
