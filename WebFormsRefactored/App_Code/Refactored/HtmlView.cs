using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UZ.UI.WebForms;

public class HtmlView : IHtmlView
{
    private readonly IHtmlViewStrategy htmlViewStrategy;

	public HtmlView()
	{
	    this.htmlViewStrategy = htmlViewStrategy;
	}

	public string GetHtml()
	{
	    return this.htmlViewStrategy.GetHtml();
	}
}