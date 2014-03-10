using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UZ.TestBackEnd.Services.Concrete;

/// <summary>
/// Descripción breve de TaskHtmlView
/// </summary>
public class TaskHtmlView : IHtmlViewStrategy
{
    private readonly TaskService taskService;

	public TaskHtmlView()
	{
		taskService = new TaskService();
	}

    public string GetHtml()
    {
        int totalNumberOfTasks = taskService.GetTotalNumberOfTasks();
    }
}