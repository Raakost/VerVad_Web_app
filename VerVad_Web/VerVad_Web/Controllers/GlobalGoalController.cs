using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Entities;

namespace VerVad_Web.Controllers
{
    public class GlobalGoalController : Controller
    {
        // GET: GlobalGoal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateGlobalGoal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateGlobalGoal(GlobalGoal gg)
        {
            return View();
        }
    }
}