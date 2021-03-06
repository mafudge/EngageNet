﻿using System.Web.Mvc;

namespace EngageNet.Mvc.Html
{
	public class EngageWidgetBuilder
	{
		private readonly HtmlHelper _htmlHelper;

		public EngageWidgetBuilder(HtmlHelper htmlHelper)
		{
			_htmlHelper = htmlHelper;
		}

		public MvcHtmlString LogOnLink(string linkText, string action, string controller)
		{
			var urlHelper = new UrlHelper(_htmlHelper.ViewContext.RequestContext);

			var tb = new TagBuilder("a");
			tb.AddCssClass("rpxnow");
			tb.Attributes.Add("onclick", "return false;");
			tb.Attributes.Add("href", urlHelper.Engage().OverlayUrl(action, controller));
			tb.SetInnerText(linkText);
			return MvcHtmlString.Create(tb.ToString(TagRenderMode.Normal));
		}

		public MvcHtmlString LogOnLinkScript()
		{
			return MvcHtmlString.Create(
				"<script type=\"text/javascript\">\n" +
				"var rpxJsHost = ((\"https:\" == document.location.protocol) ? \"https://\" : \"http://static.\");\n" +
				"document.write(unescape(\"%3Cscript src='\" + rpxJsHost + \"rpxnow.com/js/lib/rpx.js' type='text/javascript'%3E%3C/script%3E\"));\n" +
				"</script>\n" +
				"<script type=\"text/javascript\">\n" +
				"RPXNOW.overlay = true;\n" +
				"RPXNOW.language_preference = 'en';\n" +
				"</script>\n");
		}

		public MvcHtmlString InlineWidget(string action, string controller)
		{
			var urlHelper = new UrlHelper(_htmlHelper.ViewContext.RequestContext);

			var tb = new TagBuilder("iframe");
			tb.AddCssClass("rpxnow-embedded");
			tb.Attributes.Add("src", urlHelper.Engage().EmbedUrl(action, controller));
			tb.Attributes.Add("scrolling", "no");
			tb.Attributes.Add("frameborder", "no");
			tb.Attributes.Add("allowtransparency", "true");
			tb.Attributes.Add("style", "width:400px;height:240px;");
			return MvcHtmlString.Create(tb.ToString(TagRenderMode.Normal));
		}
	}
}