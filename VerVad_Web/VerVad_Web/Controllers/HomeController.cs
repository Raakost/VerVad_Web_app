using ServiceGateways.Entities;
using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerVad_Web.Controllers
{
    public class HomeController : Controller
    {
        private IServiceGateway<GlobalGoal, int> _gateway = new ServiceGatewayFacade().GetGlobalGoalServiceGateway();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_gateway.ReadAll());
        }

        public ActionResult TogglePublished(int id)
        {
            var gg = _gateway.Read(id);
            if (gg.IsPublished)
            {
                gg.IsPublished = false;
            }
            else
            {
                gg.IsPublished = true;
            }
            _gateway.Update(gg);
            return RedirectToAction("Index");
        }
    }
}