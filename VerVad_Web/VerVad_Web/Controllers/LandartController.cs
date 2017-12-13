﻿using ServiceGateways.Entities;
using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerVad_Web.ViewModels.Landart;

namespace VerVad_Web.Controllers
{
    public class LandartController : Controller
    {
        private ILanguageServiceGateway<Language> _languageGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private IChildrensServiceGateway<LandArt, int> _gateway = new ServiceGatewayFacade().GetLandArtServiceGateway();

        [HttpGet]
        public ActionResult Index(int id)
        {
            var vm = new LandArtIndexModel();
            vm.LandArts = _gateway.GetAllInstances(id);
            vm.GlobalGoalId = id;
            return View(vm);
        }

        [HttpGet]
        public ActionResult Create(int gg_id)
        {
            var vm = new LandartCreateUpdate();
            vm.GlobalGoalId = gg_id;
            vm.LandArt = new LandArt();
            vm.Languages = _languageGateway.ReadAll();
            TempData["toast"] = "Landart er oprettet!";
            return PartialView("CreateUpdate", vm);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var vm = new LandartCreateUpdate();
            vm.LandArt = _gateway.Read(id);
            vm.Languages = _languageGateway.ReadAll();
            vm.GlobalGoalId = vm.LandArt.GlobalGoalId;
            TempData["toast"] = "Dine ændringer er gemt!";
            return PartialView("CreateUpdate", vm);
        }

        [HttpPost]
        public ActionResult Create(LandartCreateUpdate vm)
        {
            var landart = _gateway.Create(vm.LandArt); 
            return RedirectToAction("Index", new { id = vm.LandArt.GlobalGoalId });
        }

        [HttpPost]
        public ActionResult Update(LandartCreateUpdate vm)
        {
            var la = new LandArt();
            {
                vm.LandArt = _gateway.Update(vm.LandArt);
                return RedirectToAction("Index", new { id = vm.LandArt.GlobalGoalId });
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _gateway.Delete(id);
            return RedirectToAction("Index");
        }
    }
}