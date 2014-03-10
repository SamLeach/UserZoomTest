using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Tasks : System.Web.UI.Page
{
    HTMLTasks HTMLTasks = new HTMLTasks();

    public string html = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        html = HTMLTasks.getHTMLTasks();
        //html = "<table><tr><td>col1</td><td>col2</td></tr><tr><td>col1</td><td>col2</td></tr></table>";
    }
}
