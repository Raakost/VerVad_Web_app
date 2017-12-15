using ServiceGateways.Entities;
using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerVad_Web.ViewModels.Artworks;

namespace VerVad_Web.Controllers
{
    public class ArtworkController : Controller
    {
        private ILanguageServiceGateway<Language> _languageGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private IChildrensServiceGateway<Artwork, int> _gateway = new ServiceGatewayFacade().GetArtworkServiceGateway();

        [HttpGet]
        public ActionResult Index(int id)
        {
            var vm = new ArtworkIndexModel();
            vm.Artworks = _gateway.GetAllInstances(id);
            vm.GlobalGoalId = id;
            return View(vm);
        }

        [HttpGet]
        public ActionResult Create(int gg_id)
        {
            var vm = new ArtworkCreateUpdate();
            vm.GlobalGoalId = gg_id;
            vm.Artwork = new Artwork();
            vm.Languages = _languageGateway.ReadAll();
            TempData["toast"] = "Artwork er oprettet!";
            return PartialView("CreateUpdate", vm);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var vm = new ArtworkCreateUpdate();
            vm.Artwork = _gateway.Read(id);
            vm.Languages = _languageGateway.ReadAll();
            vm.GlobalGoalId = vm.Artwork.GlobalGoalId;
            TempData["toast"] = "Dine ændringer er gemt!";
            return PartialView("CreateUpdate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtworkCreateUpdate vm)
        {
            var aw = _gateway.Create(vm.Artwork);
            return RedirectToAction("Index", new { id = vm.Artwork.GlobalGoalId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ArtworkCreateUpdate vm)
        {
            var aw = new LandArt();
            {
                vm.Artwork = _gateway.Update(vm.Artwork);
                return RedirectToAction("Index", new { id = vm.Artwork.GlobalGoalId });
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, int gg_id)
        {
            _gateway.Delete(id);
            return RedirectToAction("Index", new { id = gg_id });
        }
    }
}