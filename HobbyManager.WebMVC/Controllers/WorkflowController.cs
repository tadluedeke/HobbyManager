using HobbyManager.Models.Workflow;
using HobbyManager.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HobbyManager.WebMVC.Controllers
{
    [Authorize]
    public class WorkflowController : Controller
    {
        // GET: Workflow
        public ActionResult Index()
        {
            var service = CreateWorkflowService();
            var model = service.GetWorkflows();
            return View(model);
        }

        //GET: WorkflowCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: WorkflowCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkflowCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

        private WorkflowService CreateWorkflowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkflowService(userId);
            return service;
        }
    }
}