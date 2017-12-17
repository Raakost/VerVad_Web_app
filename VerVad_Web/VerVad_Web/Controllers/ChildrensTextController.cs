using ServiceGateways.Entities;
using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using ServiceGateways.ServiceGateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerVad_Web.ViewModels.ChildrensTexts;

namespace VerVad_Web.Controllers
{
    public class ChildrensTextController : Controller
    {
        private ILanguageServiceGateway<Language> _languageServiceGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private IChildrensTextServiceGateway<ChildrensText, int> _gateway = new ServiceGatewayFacade().GetChildrensTextServiceGateway();

        [HttpGet]
        public ActionResult Index(int id)
        {
            var vm = new ChildrensTextIndexModel();
            vm.ChildrensTexts = _gateway.GetTextsFromGlobalGoal(id);
            vm.GlobalGoalId = id;
            return View(vm);
        }

        [HttpGet]
        public ActionResult Create(int gg_id)
        {
            var vm = new ChildrensTextCreateUpdate();
            vm.GlobalGoalId = gg_id;
            vm.ChildrensText = new ChildrensText();
            vm.Languages = _languageServiceGateway.ReadAll();
            TempData["toast"] = "Teksten er oprettet!";
            return PartialView("CreateUpdate", vm);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var vm = new ChildrensTextCreateUpdate();
            vm.ChildrensText = _gateway.Read(id);
            vm.Languages = _languageServiceGateway.ReadAll();
            vm.GlobalGoalId = vm.ChildrensText.GlobalGoalId;
            TempData["toast"] = "Dine ændringer er gemt!";
            return PartialView("CreateUpdate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChildrensTextCreateUpdate vm)
        {
            var text = _gateway.Create(vm.ChildrensText);
            return RedirectToAction("Index", new { id = vm.ChildrensText.GlobalGoalId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ChildrensTextCreateUpdate vm)
        {
            var ct = new ChildrensText();

            {
                vm.ChildrensText = _gateway.Update(vm.ChildrensText);
                return RedirectToAction("Index", new { id = vm.ChildrensText.GlobalGoalId });
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