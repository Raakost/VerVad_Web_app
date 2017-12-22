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
using VerVad_Web.ViewModels.Landart;

namespace VerVad_Web.Controllers
{
    [LoginRequired]
    public class LandartController : Controller
    {
        private readonly ILanguageServiceGateway<Language> _languageGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private readonly IChildrensServiceGateway<LandArt, int> _gateway = new ServiceGatewayFacade().GetLandArtServiceGateway();
        private readonly CloudinaryServiceGateway _cloudinaryServiceGateway = new CloudinaryServiceGateway();

        [HttpGet]
        public ActionResult Index(int id)
        {
            var vm = new LandArtIndexModel();
            try
            {
                vm.LandArts = _gateway.GetAllInstances(id);
                vm.GlobalGoalId = id;
                return View(vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne ikke læse det valgte Landart. Prøv igen eller kontakt administrator";
                return View(new LandArtIndexModel());
            }
        }

        [HttpGet]
        public ActionResult Create(int gg_id)
        {
            var vm = new LandartCreateUpdate();
            try
            {
                vm.GlobalGoalId = gg_id;
                vm.LandArt = new LandArt();
                vm.Languages = _languageGateway.ReadAll();
                TempData["toast"] = "Landart er oprettet!";
                return PartialView("CreateUpdate", vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne ikke læse den valgte Landart. Prøv igen eller kontakt administrator";
                return PartialView("CreateUpdate", new LandartCreateUpdate());
            }

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var vm = new LandartCreateUpdate();
            try
            {
                vm.LandArt = _gateway.Read(id);
                vm.Languages = _languageGateway.ReadAll();
                vm.GlobalGoalId = vm.LandArt.GlobalGoalId;
                TempData["toast"] = "Dine ændringer er gemt!";
                return PartialView("CreateUpdate", vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne ikke læse den valgte Landart. Prøv igen eller kontakt administrator";
                return PartialView("CreateUpdate", new LandartCreateUpdate());
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LandartCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _gateway.Create(vm.LandArt);
                    TempData["toast"] = "Landart er oprettet!";
                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen");
                }
                return RedirectToAction("Index", new { id = vm.LandArt.GlobalGoalId });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Den valgte Artwork kunne ikke oprettes. Prøv igen eller kontakt administrator";
                return RedirectToAction("Index", new { id = vm.LandArt.GlobalGoalId });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(LandartCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vm.LandArt = _gateway.Update(vm.LandArt);
                    TempData["toast"] = "Landart er opdateret!";

                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig. Prøv igen!");
                }
                return RedirectToAction("Index", new { id = vm.LandArt.GlobalGoalId });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne ikke opdatere den valgte Landart. Prøv igen eller kontakt administrator";
                return RedirectToAction("Index", new { id = vm.LandArt.GlobalGoalId });
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
                TempData["toast"] = "Kunne ikke slette den valgte Landart. Prøv igen eller kontakt administrator";
                return RedirectToAction("Index", new { id = gg_id });
            }

        }
    }
}