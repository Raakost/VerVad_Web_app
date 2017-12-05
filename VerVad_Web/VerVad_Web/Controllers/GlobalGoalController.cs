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
        public ActionResult Index(GlobalGoal gg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gg = _GlobalGoalServiceGateway.Create(gg);
                    return RedirectToAction("Index");
                }

            }
            catch(Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return View(gg);
            }
            return null;
        }



    }
}