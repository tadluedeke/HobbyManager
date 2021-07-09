using HobbyManager.Models.WorkflowPaints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HobbyManager.WebMVC.Controllers
{
    [Authorize]
    public class WorkflowPaintsController : Controller
    {
        // GET: WorkflowPaints
        public ActionResult Index()
        {
            var model = new WorkflowPaintsListItem[0];
            return View(model);
        }

        //GET: WorkflowPaintsCreate
        public ActionResult Create()
        {
            return View();
        }
    }
}