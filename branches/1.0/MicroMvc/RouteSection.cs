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
    }



    public class RouteSettingsCollection : ConfigurationElementCollection
    {
        // Allow case-insensitive keys.
        public RouteSettingsCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        { }

        // Required indexer to prevent an exception when you use the GetSection method to get the section.
        public RouteSettings this[int index]
        {
            get
            {
                return (RouteSettings)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new RouteSettings this[string key]
        {
            get
            {
                return (RouteSettings)base.BaseGet(key);
            }
        }

        // When you use a BasicMap or BasicMapAlternate collection type, you have to override 
        // the IsElementName and make sure to return true if elementName is the name of your child element.
        protected override bool IsElementName(string elementName)
        {
            if ((string.IsNullOrEmpty(elementName)) || (elementName != "route"))
            {
                return false;
            }
            return true;
        }

        // When you create a collection class that inherits the ConfigurationElementCollection,
        // the CollectionType property that decide which type of collection you are going to use, 
        // will by default only support <add>, <remove> and the  <clear> element. 
        // To support your own elements, you have to override the CollectionType property 
        // and make sure to return the collection type BasicMap or BasicMapAlternate.
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RouteSettings)element).Name;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RouteSettings();
        }
    }

    public class RouteSettings : ConfigurationElement
    {
        public RouteSettings()
        { }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("url")]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
            set
            {
                this["url"] = value;
            }
        }

        [ConfigurationProperty("handler")]
        public string Handler
        {
            get
            {
                return (string)this["handler"];
            }
            set
            {
                this["handler"] = value;
            }
        }
    }
}
