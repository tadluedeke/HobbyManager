using HobbyManager.Data;
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
            List<Paint> Paints = (new PaintService()).GetPaintsList().ToList();
            var query = from p in Paints
                        select new SelectListItem()
                        {
                            Value = p.PaintId.ToString(),
                            Text = p.Name,
                        };
            ViewBag.PaintId = query.ToList();
            ViewData["Paints"] = from p in Paints
                                 select new SelectListItem()
                                 {
                                     Value = p.PaintId.ToString(),
                                     Text = p.Name,
                                 };
            return View();
        }

        //POST: WorkflowCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkflowCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWorkflowService();

            if (service.CreateWorkflow(model))
            {
                TempData["SaveResult"] = "Your workflow was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Workflow could not be created.");

            return View(model);
        }

        //GET: WorkflowDetails
        public ActionResult Details (int id)
        {
            var svc = CreateWorkflowService();
            var model = svc.GetWorkflowById(id);

            return View(model);
        }

        //GET: WorkflowEdit
        public ActionResult Edit(int id)
        {
            var service = CreateWorkflowService();

            List<Paint> Paints = (new PaintService()).GetPaintsList().ToList();
            var query = from p in Paints
                        select new SelectListItem()
                        {
                            Value = p.PaintId.ToString(),
                            Text = p.Name,
                        };
            ViewBag.PaintId = query.ToList();
            ViewData["Paints"] = from p in Paints
                                 select new SelectListItem()
                                 {
                                     Value = p.PaintId.ToString(),
                                     Text = p.Name,
                                 };

            var detail = service.GetWorkflowById(id);
            var model =
                new WorkflowEdit
                {
                    WorkflowId = detail.WorkflowId,
                    Color = detail.Color,
                    PrimeId = detail.PrimeId,
                    BaseCoatId = detail.BaseCoatId,
                    ShadeId = detail.ShadeId,
                    HighlightOneId = detail.HighlightOneId,
                    HighlightTwoId = detail.HighlightTwoId
                };
            return View(model);
        }

        //POST: WorkflowEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkflowEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.WorkflowId != id)
            {
                ModelState.AddModelError("", "Id did not match");
                return View(model);
            }

            var service = CreateWorkflowService();

            if (service.UpdateWorkflow(model))
            {
                TempData["SaveResult"] = "Your workflow was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your workflow could not be updated.");
            return View(model);
        }

        //GET: WorkflowDelete
        public ActionResult Delete(int id)
        {
            var svc = CreateWorkflowService();
            var model = svc.GetWorkflowById(id);

            return View(model);
        }

        //POST: WorkflowDelete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWorkflow(int id)
        {
            var service = CreateWorkflowService();

            service.DeleteWorkflow(id);

            TempData["SaveResult"] = "Your workflow was successfully deleted";

            return RedirectToAction("Index");
        }

        private WorkflowService CreateWorkflowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkflowService(userId);
            return service;
        }
    }
}