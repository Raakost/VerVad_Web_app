using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerVad_Web.Models;

namespace VerVad_Web.Controllers
{
    public class GlobalGoalController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}