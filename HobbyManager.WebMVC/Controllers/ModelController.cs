using HobbyManager.Models;
using HobbyManager.Models.Model;
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
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index()
        {
            var service = CreateModelService();

            var model = service.GetModels();

            return View(model);
        }

        // GET: ModelCreate
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateModelService();

            if (service.CreateModel(model))
            {
                TempData["SaveResult"] = "Your model was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Model could not be created.");

            return View(model);
        }

        // GET: ModelDetail
        public ActionResult Details(int id)
        {
            var svc = CreateModelService();
            var model = svc.GetModelById(id);

            return View(model);
        }

        // GET: ModelEdit
        public ActionResult Edit(int id)
        {
            var service = CreateModelService();
            var detail = service.GetModelById(id);
            var model =
                new ModelEdit
                {
                    ModelId = detail.ModelId,
                    Name = detail.Name,
                    Scale = detail.Scale,
                    Brand = detail.Brand
                };
            return View(model);
        }

        // POST: ModelEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ModelEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ModelId != id)
            {
                ModelState.AddModelError("", "Id did not match.");
                return View(model);
            }

            var service = CreateModelService();

            if (service.UpdateModel(model))
            {
                TempData["SaveResult"] = "Your model was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your model could not be updated.");
            return View();
        }

        // GET: ModelDelete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateModelService();
            var model = svc.GetModelById(id);

            return View(model);
        }

        // Post: ModelDelete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteModel(int id)
        {
            var service = CreateModelService();

            service.DeleteModel(id);

            TempData["SaveResult"] = "Your model was successfully deleted.";

            return RedirectToAction("Index");
        }

        private ModelService CreateModelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ModelService(userId);
            return service;
        }
    }
}