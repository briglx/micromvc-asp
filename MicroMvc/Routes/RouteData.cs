using System;
using System.Collections.Generic;
using System.Text;

namespace MicroMvc
{
    public class RouteData
    {
        public Dictionary<string, string> Values { get; set; }
        public Route Route { get; set; }

        public RouteData()
        {
            this.Values = new Dictionary<string, string>();
        }

        public static RouteData Parse(Uri uri)
        {
            return new RouteData();
        }
    }
}
