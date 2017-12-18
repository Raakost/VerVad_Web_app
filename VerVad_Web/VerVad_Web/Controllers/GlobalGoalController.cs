using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerVad_Web.ViewModels.GlobalGoals;
using ServiceGateways.ServiceGateways;
using VerVad_Web.DataAnnotations;

namespace VerVad_Web.Controllers
{
    [LoginRequired]
    public class GlobalGoalController : Controller
    {
        private IServiceGateway<GlobalGoal, int> _GlobalGoalServiceGateway = new ServiceGatewayFacade().GetGlobalGoalServiceGateway();
        private ILanguageServiceGateway<Language> _languageServiceGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();

        [HttpGet]
        public ActionResult Index()
        {
            var vm = new GlobalGoalCreateUpdate();
            vm.GlobalGoal = new GlobalGoal();
            vm.Languages = _languageServiceGateway.ReadAll();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GlobalGoalCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var gg = _GlobalGoalServiceGateway.Create(vm.GlobalGoal);
                    TempData["toast"] = "Verdensmålet er oprettet!";
                    return RedirectToAction("Update", new { id = gg.Id });

                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return RedirectToAction("Index", vm.GlobalGoal);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return RedirectToAction("Index", vm.GlobalGoal);
            }

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var gg = _GlobalGoalServiceGateway.Read(id);
                var vm = new GlobalGoalCreateUpdate();
                vm.GlobalGoal = gg;
                vm.Languages = _languageServiceGateway.ReadAll();

                return View(vm);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GlobalGoalCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vm.GlobalGoal = _GlobalGoalServiceGateway.Update(vm.GlobalGoal);
                    TempData["toast"] = "Dine ændringer er gemt!";
                    return RedirectToAction("Update");
                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return View("Update", vm);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return View("Update", vm);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _GlobalGoalServiceGateway.Delete(id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home", e.Message);
            }
        }
    }
}