using HobbyManager.Models.Project;
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
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            var service = CreateProjectService();
            var model = service.GetProjects();

            return View(model);
        }

        //GET: ProjectCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: ProjectCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectService();

            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = "Your project was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Project could not be created.");

            return View(model);
        }

        //GET: ProjectDetails
        public ActionResult Details(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        //GET: ProjectEdit
        public ActionResult Edit(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);
            var model =
                new ProjectEdit
                {
                    ProjectId = detail.ProjectId,
                    Name = detail.Name,
                    StartDate = detail.StartDate,
                    FinishDate = detail.FinishDate
                };
            return View(model);
        }

        //POST: ProjectEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProjectId != id)
            {
                ModelState.AddModelError("", "Id did not match.");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))
            {
                TempData["SaveResult"] = "Your project was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your project could not be updated.");
            return View();
        }

        //GET: ProjectDelete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        //POST: ProjectDelete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProject(int id)
        {
            var service = CreateProjectService();

            service.DeleteProject(id);

            TempData["SaveResult"] = "Your project was successfully deleted.";

            return RedirectToAction("Index");
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }
    }
}