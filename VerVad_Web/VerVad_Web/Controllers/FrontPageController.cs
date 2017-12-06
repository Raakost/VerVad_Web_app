using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerVad_Web.ViewModels.FrontPageUpdate;

namespace VerVad_Web.Controllers
{
    public class FrontPageController : Controller
    {
        [HttpGet]
        public ActionResult Update(int id)
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Update(FrontPageUpdateViewModel vm)
        {

            return View(vm);
        }
    }
}