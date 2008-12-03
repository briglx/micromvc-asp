using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MicroMvc
{
    public sealed class RouteCollection
    {

        private static RouteCollection _instance;
        private static object _syncRoot = typeof(RouteCollection);

        private IList<Route> Routes;

        private RouteCollection()
        {
            lock (_syncRoot)
            {
                this.Routes = new List<Route>();
            }

        }

        public static RouteCollection Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new RouteCollection();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Add(Route route)
        {
            lock (_syncRoot)
            {
                this.Routes.Add(route);
            }
        }

        public RouteData GetRouteData(Uri uri)
        {
            RouteData routeData = null;

            lock (_syncRoot)
            {
                bool found;

                // Cycle through each route to find one that matches the passed in uri
                foreach (Route r in this.Routes)
                {
                    if (r.Match(uri))
                    {
                        routeData = new RouteData();
                        routeData.Route = r;

                        // Get Group 
                        Regex reg = new Regex(r.Pattern, RegexOptions.IgnoreCase);
                        GroupCollection groups = reg.Match(uri.ToString()).Groups;

                        foreach (string groupName in r.Parameters)
                        {
                            routeData.Values.Add(groupName, groups[groupName].Value);
                        }
                        break;

                    }
                }
            }
            return routeData;
        }

        //private IList<KeyValuePair<string, string>> GetParameters(Route route, Uri uri)
        //{

        //    List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

        //    string pattern = route.Pattern;

        //    Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);

        //    reg.Match(uri.ToString());

        //    foreach (Group group in reg.Match(uri.ToString()).Groups)
        //    {
        //        list.Add(new KeyValuePair<string, string>(group.Value, group.Value));
        //    }

        //    return list;
        //}
    }
}
