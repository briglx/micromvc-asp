﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MicroMvc
{
    public class TextView<T> : IBaseView<T>
    {
        public T ViewData { get; set; }
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string result = this.ViewData.ToString();

            context.Response.ContentType = "text/text";
            context.Response.Write(result);
            context.Response.End();
        }
    }
}