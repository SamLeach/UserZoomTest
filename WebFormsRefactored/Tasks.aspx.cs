using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UZ.TestBackEnd.Services.Concrete;

public partial class _Tasks : System.Web.UI.Page
{
    TaskService taskService = new TaskService();

    public string html = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        html = taskService.GetTotalNumberOfTasksHtml();
        //html = "<table><tr><td>col1</td><td>col2</td></tr><tr><td>col1</td><td>col2</td></tr></table>";
    }
}
