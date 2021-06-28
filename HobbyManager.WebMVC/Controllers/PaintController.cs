using HobbyManager.Models.Paint;
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
            var model = new PaintListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}