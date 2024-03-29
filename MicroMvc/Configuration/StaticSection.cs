﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MicroMvc
{
    public class StaticSection : ConfigurationElement
    {
        [ConfigurationProperty("dir", IsRequired = true, IsKey = false)]
        public string Directory
        {

            get
            {
                return (string)this["dir"];
            }
            set
            {
                this["dir"] = value;
            }

        }

        [ConfigurationProperty("fileset",
            IsDefaultCollection = false)]
        public FilesetCollection Fileset
        {
            get
            {
                FilesetCollection filesetCollection =
                (FilesetCollection)base["fileset"];
                return filesetCollection;
            }
        }
    }

    public class FilesetCollection : ConfigurationElementCollection
    {
        // Allow case-insensitive keys.
        public FilesetCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        { }

        public IncludeSettings this[int index]
        {
            get
            {
                return (IncludeSettings)base.BaseGet(index);
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

        public new IncludeSettings this[string key]
        {
            get
            {
                return (IncludeSettings)base.BaseGet(key);
            }
        }

        // When you use a BasicMap or BasicMapAlternate collection type, you have to override 
        // the IsElementName and make sure to return true if elementName is the name of your child element.
        protected override bool IsElementName(string elementName)
        {
            if ((string.IsNullOrEmpty(elementName)) || (elementName != "include"))
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
            return ((IncludeSettings)element).Name;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new IncludeSettings();
        }




    }

    public class IncludeSettings : ConfigurationElement
    {
        public IncludeSettings()
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

    }
}
