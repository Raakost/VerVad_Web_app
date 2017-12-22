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
using VerVad_Web.ViewModels.Artworks;

namespace VerVad_Web.Controllers
{
    [LoginRequired]
    public class ArtworkController : Controller
    {
        private readonly ILanguageServiceGateway<Language> _languageGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private readonly IChildrensServiceGateway<Artwork, int> _gateway = new ServiceGatewayFacade().GetArtworkServiceGateway();
        private readonly CloudinaryServiceGateway _cloudinaryServiceGateway = new CloudinaryServiceGateway();

        [HttpGet]
        public ActionResult Index(int id)
        {
            var vm = new ArtworkIndexModel();
            try
            {
                
                vm.Artworks = _gateway.GetAllInstances(id);
                vm.GlobalGoalId = id;
                return View(vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Der skete en fejl. Prøv igen eller kontakt administrator!";
                return View(new ArtworkIndexModel());
            }

        }

        [HttpGet]
        public ActionResult Create(int gg_id)
        {
            var vm = new ArtworkCreateUpdate();
            try
            {

                vm.GlobalGoalId = gg_id;
                vm.Artwork = new Artwork();
                vm.Languages = _languageGateway.ReadAll();
                TempData["toast"] = "Artwork er oprettet!";
                return PartialView("CreateUpdate", vm);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Der skete en fejl. Prøv igen eller kontakt administrator!";
                return PartialView("CreateUpdate", new ArtworkCreateUpdate());
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var vm = new ArtworkCreateUpdate();
            try
            {
                
                vm.Artwork = _gateway.Read(id);
                vm.Languages = _languageGateway.ReadAll();
                vm.GlobalGoalId = vm.Artwork.GlobalGoalId;
                TempData["toast"] = "Dine ændringer er gemt!";
                return PartialView("CreateUpdate", vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Der skete en fejl. Prøv igen eller kontakt administrator!";
                return PartialView("CreateUpdate", new ArtworkCreateUpdate());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtworkCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _gateway.Create(vm.Artwork);
                    TempData["toast"] = "Artwork er oprettet!";
                    return RedirectToAction("Index", new { id = vm.Artwork.GlobalGoalId });

                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return RedirectToAction("Index", vm.Artwork.GlobalGoalId);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Den valgte Artwork kunne ikke oprettes. Prøv igen eller kontakt administrator";
                return RedirectToAction("Index", vm);
            }
            
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ArtworkCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vm.Artwork = _gateway.Update(vm.Artwork);
                    TempData["toast"] = "Artwork er opdateret!";
                    return RedirectToAction("Index", new { id = vm.Artwork.GlobalGoalId });

                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return RedirectToAction("Index", vm.Artwork.GlobalGoalId);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                TempData["toast"] = "Kunne ikke opdatere den valgte Artwork. Prøv igen eller kontakt administrator";
                return RedirectToAction("Index", vm);
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
                TempData["toast"] = "Kunne ikke ¨slette den valgte Artwork. Prøv igen eller kontakt administrator";
                return RedirectToAction("Index", new { id = gg_id });
            }

        }
    }
}