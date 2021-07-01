using HobbyManager.Models.ProjectWorkflow;
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
    public class ProjectWorkflowController : Controller
    {
        // GET: ProjectWorkflow
        public ActionResult Index()
        {
            var service = CreateProjectWorkflowService();
            var model = service.GetProjectWorkflows();

            return View(model);
        }

        //GET: ProjectWorkflowCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: ProjectWorkflowCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectWorkflowCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectWorkflowService();

            if (service.CreateProjectWorkflow(model))
            {
                TempData["SaveResult"] = "Your ProjectWorkflow was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "ProjectWorkflow could not be created.");

            return View(model);
        }

        //GET: ProjectWorkflowById
        public ActionResult Details(int id)
        {
            var svc = CreateProjectWorkflowService();
            var model = svc.GetProjectWorkflowById(id);

            return View(model);
        }

        //GET: ProjectWorkflowEdit
        public ActionResult Edit(int id)
        {
            var service = CreateProjectWorkflowService();
            var detail = service.GetProjectWorkflowById(id);
            var model =
                new ProjectWorkflowEdit
                {
                    ProjectWorkflowId = detail.ProjectWorkflowId,
                    ProjectId = detail.ProjectId,
                    WorkflowId = detail.WorkflowId
                };
            return View(model);
        }

        //POST: ProjectWorkflowEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectWorkflowEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ProjectWorkflowId != id)
            {
                ModelState.AddModelError("", "Id did not match.");
                return View(model);
            }

            var service = CreateProjectWorkflowService();

            if (service.UpdateProjectWorkflow(model))
            {
                TempData["SaveResult"] = "Your ProjectWorkflow was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ProjectWorkflow could not be updated.");
            return View(model);
        }

        //GET: ProjectWorkflowDelete
        public ActionResult Delete(int id)
        {
            var svc = CreateProjectWorkflowService();
            var model = svc.GetProjectWorkflowById(id);

            return View(model);
        }

        //POST: ProjectWorkflowDelete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProjectWorkflow(int id)
        {
            var service = CreateProjectWorkflowService();

            service.DeleteProjectWorkflow(id);

            TempData["SaveResult"] = "Your ProjectWorkflow was successfully deleted.";

            return RedirectToAction("Index");
        }

        private ProjectWorkflowService CreateProjectWorkflowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectWorkflowService(userId);
            return service;
        }
    }
}