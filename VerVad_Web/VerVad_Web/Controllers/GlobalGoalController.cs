using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using VerVad_Web.ViewModels.GlobalGoals;
using ServiceGateways.ServiceGateways;
using VerVad_Web.DataAnnotations;

namespace VerVad_Web.Controllers
{
    [LoginRequired]
    public class GlobalGoalController : Controller
    {
        private readonly IServiceGateway<GlobalGoal, int> _globalGoalServiceGateway = new ServiceGatewayFacade().GetGlobalGoalServiceGateway(); 
        private readonly ILanguageServiceGateway<Language> _languageServiceGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private readonly CloudinaryServiceGateway _cloudinaryServiceGateway = new CloudinaryServiceGateway();

        [HttpGet]
        public ActionResult Index()
        {
            var vm = new GlobalGoalCreateUpdate();
            try
            {
                vm.GlobalGoal = new GlobalGoal();
                vm.Languages = _languageServiceGateway.ReadAll();
                vm.Folders = _cloudinaryServiceGateway.GetGlobalGoalFolders();
                return View(vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne ikke læse det valgte Verdensmål. Prøv igen eller kontakt administrator";
                return View(vm);
            }
        }

        //[HttpGet]
        //public ActionResult GetImageModal(string folderPath, int gg_id)
        //{
        //    var images = _cloudinaryServiceGateway.GetImages(folderPath);
        //    return PartialView();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GlobalGoalCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var gg = _globalGoalServiceGateway.Create(vm.GlobalGoal);
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
                var gg = _globalGoalServiceGateway.Read(id);
                var vm = new GlobalGoalCreateUpdate();
                vm.GlobalGoal = gg;
                vm.Languages = _languageServiceGateway.ReadAll();
                vm.Folders = _cloudinaryServiceGateway.GetGlobalGoalFolders();

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
                    vm.GlobalGoal = _globalGoalServiceGateway.Update(vm.GlobalGoal);
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
                _globalGoalServiceGateway.Delete(id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index", "Home", "Kunne ikke slette. Prøv igen eller kontakt administrator");
            }
        }
    }
}