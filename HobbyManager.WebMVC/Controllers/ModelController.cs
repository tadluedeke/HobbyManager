using HobbyManager.Models;
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
    }
}