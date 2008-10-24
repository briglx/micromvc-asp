using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MicroMvc
{
    internal class UrlHelper
    {
        /// <summary>
        /// Returns a site relative HTTP path from a partial path starting out with a ~.
        /// Same syntax that ASP.Net internally supports but this method can be used
        /// outside of the Page framework.
        /// 
        /// Works like Control.ResolveUrl including support for ~ syntax
        /// but returns an absolute URL.
        /// </summary>
        /// <param name="relativeUrl">Any Url including those starting with ~</param>
        /// <returns>relative url</returns>
        public static string ResolveUrl(string relativeUrl)
        {
            if (string.IsNullOrEmpty(relativeUrl))
                return relativeUrl;

            // *** Absolute path - just return
            if (IsAbsolutePath(relativeUrl))
                return relativeUrl;

            // *** We don't start with the '~' -> we don't process the Url
            if (!relativeUrl.StartsWith("~"))
                return relativeUrl;

            // *** Fix up path for ~ root app dir directory
            // VirtualPathUtility blows up if there is a 
            // query string, so we have to account for this.
            int queryStringStartIndex = relativeUrl.IndexOf('?');
            if (queryStringStartIndex != -1)
            {
                string queryString = relativeUrl.Substring(queryStringStartIndex);
                string baseUrl = relativeUrl.Substring(0, queryStringStartIndex);

                return string.Concat(
                    VirtualPathUtility.ToAbsolute(baseUrl),
                    queryString);
            }
            else
            {
                return VirtualPathUtility.ToAbsolute(relativeUrl);
            }

        }

        /// <summary>
        /// This method returns a fully qualified absolute server Url which includes
        /// the protocol, server, port in addition to the server relative Url.
        /// 
        /// Works like Control.ResolveUrl including support for ~ syntax
        /// but returns an absolute URL.
        /// </summary>
        /// <param name="ServerUrl">Any Url, either App relative or fully qualified</param>
        /// <param name="forceHttps">if true forces the url to use https</param>
        /// <returns></returns>
        public static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (string.IsNullOrEmpty(serverUrl))
                return serverUrl;

            // *** Is it already an absolute Url?
            if (IsAbsolutePath(serverUrl))
                return serverUrl;

            string newServerUrl = ResolveUrl(serverUrl);
            Uri result = new Uri(HttpContext.Current.Request.Url, newServerUrl);

            if (!forceHttps)
                return result.ToString();
            else
                return ForceUriToHttps(result).ToString();

        }

        /// <summary>
        /// This method returns a fully qualified absolute server Url which includes
        /// the protocol, server, port in addition to the server relative Url.
        /// 
        /// It work like Page.ResolveUrl, but adds these to the beginning.
        /// This method is useful for generating Urls for AJAX methods
        /// </summary>
        /// <param name="ServerUrl">Any Url, either App relative or fully qualified</param>
        /// <returns></returns>
        public static string ResolveServerUrl(string serverUrl)
        {
            return ResolveServerUrl(serverUrl, false);
        }

        /// <summary>
        /// Forces the Uri to use https
        /// </summary>
        private static Uri ForceUriToHttps(Uri uri)
        {
            // ** Re-write Url using builder.
            UriBuilder builder = new UriBuilder(uri);
            builder.Scheme = Uri.UriSchemeHttps;
            builder.Port = 443;

            return builder.Uri;
        }

        private static bool IsAbsolutePath(string relativeUrl)
        {
            // *** Absolute path - just return
            int IndexOfSlashes = relativeUrl.IndexOf("://");
            int IndexOfQuestionMarks = relativeUrl.IndexOf("?");

            if (IndexOfSlashes > -1 &&
                 (IndexOfQuestionMarks < 0 ||
                  (IndexOfQuestionMarks > -1 && IndexOfQuestionMarks > IndexOfSlashes)
                  )
                )
                return true;

            return false;
        }
    }
}
