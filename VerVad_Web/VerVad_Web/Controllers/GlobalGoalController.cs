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
        public ActionResult CreateEditGlobalGoal(GlobalGoal gg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(gg.Id == 0 || gg.Id.Equals(null))
                    { 
                    gg = _GlobalGoalServiceGateway.Create(gg);
                    return RedirectToAction("Index");
                    }
                    else {
                        gg = _GlobalGoalServiceGateway.Update(gg);
                        return RedirectToAction("Home");
                    }
                }

            }
            catch(Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return View(gg);
            }
            return null;
        }

        public ActionResult Index(int id)
        {
            try
            {
                var gg = _GlobalGoalServiceGateway.Read(id);
                return View(gg);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }



    }
}