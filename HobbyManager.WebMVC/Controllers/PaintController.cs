using HobbyManager.Models.Paint;
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
    public class PaintController : Controller
    {
        // GET: Paint
        public ActionResult Index()
        {
            var service = CreatePaintService();
            var model = service.GetPaints();
            
            return View(model);
        }

        // GET: PaintCreate
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaintCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaintCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePaintService();

            if (service.CreatePaint(model))
            {
                TempData["SaveResult"] = "Your paint was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Paint could not be created.");

            return View(model);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreatePaintService();
            var model = svc.GetPaintById(id);

            return View(model);
        }

        //GET: PaintEdit
        public ActionResult Edit(int id)
        {
            var service = CreatePaintService();
            var detail = service.GetPaintById(id);
            var model =
                new PaintEdit
                {
                    PaintId = detail.PaintId,
                    Brand = detail.Brand,
                    Name = detail.Name,
                    Color = detail.Color,
                    SKU = detail.SKU
                };
            return View(model);
        }

        //POST: PaintEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PaintEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.PaintId != id)
            {
                ModelState.AddModelError("", "Id did not match.");
                return View(model);
            }

            var service = CreatePaintService();

            if (service.UpdatePaint(model))
            {
                TempData["SaveResult"] = "Your paint was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your paint could not be updated.");
            return View(model);
        }

        //GET: PaintDelete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePaintService();
            var model = svc.GetPaintById(id);

            return View(model);
        }

        //POST: PaintDelete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePaint(int id)
        {
            var service = CreatePaintService();

            service.DeletePaint(id);

            TempData["SaveResult"] = "Your note was successfully deleted.";

            return RedirectToAction("Index");
        }

        private PaintService CreatePaintService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PaintService(userId);
            return service;
        }
    }
}