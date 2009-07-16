using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MicroMvc
{
    public sealed class MvcSection : ConfigurationSection
    {
        [ConfigurationProperty("routes", IsDefaultCollection = false, IsRequired = true)]
        [ConfigurationCollection(typeof(RouteSettingsCollection), AddItemName = "route")]
        public RouteSettingsCollection Routes
        {
            get
            {
                RouteSettingsCollection routes = ((RouteSettingsCollection)base["routes"]);
                return routes;
            }
        }


        [ConfigurationProperty("static", IsDefaultCollection = false, IsRequired = false)]
        public StaticSection Static
        {
            get
            {
                StaticSection staticFiles = ((StaticSection)base["static"]);
                return staticFiles;
            }
        }
    }
}
