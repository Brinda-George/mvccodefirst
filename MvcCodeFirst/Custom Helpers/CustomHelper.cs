using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Custom_Helpers
{
    public static class CustomHelper
    {
        public static IHtmlString File(this HtmlHelper helper, string id)
        {
            TagBuilder tb = new TagBuilder("input");
            tb.Attributes.Add("type", "file");
            tb.Attributes.Add("id", id);
            return new MvcHtmlString(tb.ToString());
        }
        public static IHtmlString Image(this HtmlHelper helper, string src, string height)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("height", height);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString RedLabel(string content)
        {
            return new MvcHtmlString("<label style='color: red;'>" + content + "</Label>");
        }
        public static MvcHtmlString RedLabel(this HtmlHelper helper, string content)
        {
            return new MvcHtmlString("<label style='color: red;'>" + content + "</Label>");
        }
        public static string AppendString(this string str)
        {
            return str + "Hello";
        }
    }  
}