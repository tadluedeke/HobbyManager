using HobbyManager.Models.Project;
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
            var model = new ProjectListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
    }
}