using ServiceGateways.Entities;
using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using ServiceGateways.ServiceGateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerVad_Web.DataAnnotations;
using VerVad_Web.ViewModels.ChildrensTexts;

namespace VerVad_Web.Controllers
{
    [LoginRequired]
    public class ChildrensTextController : Controller
    {
        private readonly ILanguageServiceGateway<Language> _languageServiceGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private readonly IChildrensTextServiceGateway<ChildrensText, int> _gateway = new ServiceGatewayFacade().GetChildrensTextServiceGateway();

        [HttpGet]
        public ActionResult Index(int id)
        {
            var vm = new ChildrensTextIndexModel();
            try
            {
                vm.ChildrensTexts = _gateway.GetTextsFromGlobalGoal(id);
                vm.GlobalGoalId = id;
                return View(vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne ikke læse det valgte ChildrensText. Prøv igen eller kontakt administrator";
                return View(new ChildrensTextIndexModel());
            }
            

        }

        [HttpGet]
        public ActionResult Create(int gg_id)
        {
            var vm = new ChildrensTextCreateUpdate();
            try
            {
                vm.GlobalGoalId = gg_id;
                vm.ChildrensText = new ChildrensText();
                vm.Languages = _languageServiceGateway.ReadAll();
                TempData["toast"] = "Teksten er oprettet!";
                return PartialView("CreateUpdate", vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Fejl i indlæsning af ChildrensText. Prøv igen eller kontakt administrator";
                return PartialView("CreateUpdate", new ChildrensTextCreateUpdate());
            }
            

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var vm = new ChildrensTextCreateUpdate();
            try
            {
                vm.ChildrensText = _gateway.Read(id);
                vm.Languages = _languageServiceGateway.ReadAll();
                vm.GlobalGoalId = vm.ChildrensText.GlobalGoalId;
                TempData["toast"] = "Dine ændringer er gemt!";
                return PartialView("CreateUpdate", vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Fejl i indlæsning af ChildrensText. Prøv igen eller kontakt administrator";
                return PartialView("CreateUpdate", new ChildrensTextCreateUpdate());
            }
            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChildrensTextCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var text = _gateway.Create(vm.ChildrensText);
                    return RedirectToAction("Index", new {id = vm.ChildrensText.GlobalGoalId});
                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return RedirectToAction("Index", new {id = vm.ChildrensText.GlobalGoalId});
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne ikke oprette den valgte ChildrensText. Prøv igen eller kontakt administrator";
                return RedirectToAction("Index", vm.ChildrensText);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ChildrensTextCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vm.ChildrensText = _gateway.Update(vm.ChildrensText);
                    return RedirectToAction("Index", new { id = vm.ChildrensText.GlobalGoalId });
                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return RedirectToAction("Index", new { id = vm.ChildrensText.GlobalGoalId });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return RedirectToAction("Index", vm.ChildrensText);
            }

        }

        [HttpPost]
        public ActionResult Delete(int id, int gg_id)
        {
            try
            {
                _gateway.Delete(id);
                return RedirectToAction("Index", new { id = gg_id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne ikke slette den valgte ChildrensText. Prøv igen eller kontakt administrator";
                return RedirectToAction("Index", new { id = gg_id });
            }

        }
    }
}