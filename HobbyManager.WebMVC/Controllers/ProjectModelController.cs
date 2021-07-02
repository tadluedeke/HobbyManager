using HobbyManager.Models.ProjectModel;
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
    public class ProjectModelController : Controller
    {
        // GET: ProjectModel
        public ActionResult Index()
        {
            var service = CreateProjectModelService();
            var model = service.GetProjectModels();

            return View(model);
        }

        //GET: ProjectModelCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: ProjectModelCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectModelCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectModelService();

            if (service.CreateProjectModel(model))
            {
                TempData["SaveResult"] = "Your ProjectModel was successfully created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "ProjectModel could not be created.");

            return View(model);
        }

        //GET: ProjectModelDetail
        public ActionResult Details(int id)
        {
            var svc = CreateProjectModelService();
            var model = svc.GetProjectModelById(id);

            return View(model);
        }

        //GET: ProjectModelEdit
        public ActionResult Edit(int id)
        {
            var service = CreateProjectModelService();
            var detail = service.GetProjectModelById(id);
            var model =
                new ProjectModelEdit
                {
                    ProjectModelId = detail.ProjectModelId,
                    ProjectId = detail.ProjectId,
                    ModelId = detail.ModelId
                };
            return View(model);
        }

        //POST: ProjectModelEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectModelEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ProjectModelId != id)
            {
                ModelState.AddModelError("", "Id did not match.");
            }

            var service = CreateProjectModelService();

            if (service.UpdateProjectModel(model))
            {
                TempData["SaveResult"] = "Your ProjectModel was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ProjecetModel could not be updated.");
            return View(model);
        }

        //GET: ProjectModelDelete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProjectModelService();
            var model = svc.GetProjectModelById(id);

            return View(model);
        }

        //POST: ProjectModelDelete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProjectModel(int id)
        {
            var service = CreateProjectModelService();

            service.DeleteProjectModel(id);

            TempData["SaveResult"] = "Your ProjectModel was deleted.";

            return RedirectToAction("Index");
        }

        private ProjectModelService CreateProjectModelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectModelService(userId);
            return service;
        }
    }
}