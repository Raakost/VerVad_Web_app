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
        public ActionResult Create(GlobalGoal gg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gg = _GlobalGoalServiceGateway.Create(gg);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return RedirectToAction("Index", gg);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return RedirectToAction("Index", gg);
            }
        }

        public ActionResult Update(GlobalGoal gg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gg = _GlobalGoalServiceGateway.Update(gg);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return RedirectToAction("Index", gg);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return RedirectToAction("Index", gg);
            }
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