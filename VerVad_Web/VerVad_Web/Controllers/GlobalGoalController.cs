using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerVad_Web.Controllers
{
    public class GlobalGoalController : Controller
    {
        private IServiceGateway<GlobalGoal, int> _GlobalGoalServiceGateway = new ServiceGatewayFacade().GetGlobalGoalServiceGateway();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind(Include ="Latitude,Longtitude, ImgUrl, Translation.TranslatedTexts")]GlobalGoal gg)
        {
            if (ModelState.IsValid)
            {
                gg = _GlobalGoalServiceGateway.Create(gg);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }



    }
}