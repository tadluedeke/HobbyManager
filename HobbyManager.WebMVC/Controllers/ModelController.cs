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
                TempData["SaveResult"] = "Your model was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Model could not be created.");

            return View(model);
        }

        private ModelService CreateModelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ModelService(userId);
            return service;
        }
    }
}