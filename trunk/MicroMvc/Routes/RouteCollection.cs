using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MicroMvc
{
    public class RouteCollection
    {
        List<Route> Routes;

        public RouteCollection()
        {
            Routes = new List<Route>();
        }

        public void Add(Route route)
        {
            this.Routes.Add(route);
        }

        public RouteData GetRouteData(Uri uri)
        {
            Object syncRoot = new object();

            //lock (syncRoot)
            //{
                RouteData routeData = new RouteData();

                // Cycle through each route to find one that matches the passed in uri
                foreach (Route r in this.Routes)
                {
                    if (r.Match(uri))
                    {
                        routeData.Route = r;

                        // Get Group 
                        Regex reg = new Regex(r.Pattern, RegexOptions.IgnoreCase);
                        GroupCollection groups = reg.Match(uri.ToString()).Groups;

                        foreach (string groupName in r.Parameters)
                        {
                            routeData.Values.Add(groupName, groups[groupName].Value);
                        }

                        return routeData;
                    }
                }

                return null;
            //}
           
        }

        private List<KeyValuePair<string,string>> GetParameters(Route route, Uri uri)
        {

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            string pattern = route.Pattern;

            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);

            reg.Match(uri.ToString());

            foreach (Group group in reg.Match(uri.ToString()).Groups)
            {
                list.Add(new KeyValuePair<string, string>(group.Value, group.Value));
            }

            return list;
        }
    }
}
