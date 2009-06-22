using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MicroMvc
{
    public class Route
    {
        private string _url;
        private string _pattern;
        private string _handler;
        private bool _construct;
        private List<string> _parameters;

        public Route(){}
        public Route(string url, string handler, bool construct)
        {
            this.Construct = construct;
            this.Url = url;
            this.Handler = handler;
        }
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                _pattern = ConstructPattern(_url, _construct);
                _parameters = GetParameters(_url);
            }
        }
        public string Pattern
        {
            get { return _pattern; }
        }
        public bool Construct
        {
            get{return _construct;}
            set{_construct = value;}
        }
        public string Handler
        {
            get { return _handler; }
            set { _handler = value; }
        }
        public List<string> Parameters
        {
            get { return _parameters; }
        }

        public bool Match(Uri uri)
        {
            string input = uri.ToString();

            // Use the this.URL to pattern match with the passed in uri
            Regex r = new Regex(this.Pattern, RegexOptions.IgnoreCase);
            return r.IsMatch(input);
        }

        private string ConstructPattern(string url, bool construct)
        {
            // Example:
            // Default.aspx/[userId]
            // Default.aspx/?<userId>(\w+)

            string pattern = "";

            if (construct)
            {
                pattern = url.Replace("[", "(?<");
                pattern = pattern.Replace("]", ">[^/^?]+)");
            }
            else
            {
                pattern = url.Replace("[", "<");
                pattern = pattern.Replace("]", ">");

                pattern = pattern.Replace("1$", "[");
                pattern = pattern.Replace("$1", "]");
            }

            return pattern;
        }

        private List<string> GetParameters(string url)
        {
            // Default.aspx/[userId] 
            // userId

            List<string> items = new List<string>();

            Regex r = new Regex("\\[\\w*\\]", RegexOptions.IgnoreCase);
            MatchCollection matches = r.Matches(url);

            foreach(Match m in  matches)
            {

                items.Add(m.Value.Replace("[", string.Empty).Replace("]", string.Empty));
            }

            return items;
        }
    }
}
