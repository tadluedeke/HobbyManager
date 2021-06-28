using HobbyManager.Models;
using HobbyManager.Models.Model;
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
            var model = new ModelListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}