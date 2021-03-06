﻿using ServiceGateways.Entities;
using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using ServiceGateways.ServiceGateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerVad_Web.DataAnnotations;
using VerVad_Web.ViewModels.AudioVideos;

namespace VerVad_Web.Controllers
{
    [LoginRequired]
    public class AudioVideoController : Controller
    {
        private readonly ILanguageServiceGateway<Language> _languageServiceGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private readonly AudioVideoServiceGateway _gateway = (AudioVideoServiceGateway)new ServiceGatewayFacade().GetAudioVideoServiceGateway();

        [HttpGet]
        public ActionResult Create(int gg_id)
        {
            var vm = new AudioVideoCreateUpdate();
            try
            {
                
                vm.AudioVideo = new AudioVideo()
                {
                    Id = gg_id
                };
                vm.Languages = _languageServiceGateway.ReadAll();
                vm.IsCreate = true;
                return View("CreateUpdate", vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("CreateUpdate",new AudioVideoCreateUpdate());
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AudioVideoCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var av = _gateway.Create(vm.AudioVideo);
                    TempData["toast"] = "Audio og Video er oprettet!";
                    return RedirectToAction("Update", new { id = av.Id });

                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return RedirectToAction("Update", "GlobalGoal", new { id = vm.AudioVideo.Id });
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return RedirectToAction("Update", "GlobalGoal", vm.AudioVideo.Id);
            }
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var vm = new AudioVideoCreateUpdate();
            try
            {
                var av = _gateway.Read(id);
                
                vm.AudioVideo = av;
                vm.Languages = _languageServiceGateway.ReadAll();

                return View("CreateUpdate", vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne inne finde den valgte AudioVideo. Prøv igen eller kontakt administrator";
                return View("CreateUpdate", new AudioVideoCreateUpdate());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(AudioVideoCreateUpdate vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vm.AudioVideo = _gateway.Update(vm.AudioVideo);
                    TempData["toast"] = "Dine ændringer er gemt!";
                    return RedirectToAction("Update", "GlobalGoal", new { id = vm.AudioVideo.Id });
                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return View("CreateUpdate", vm);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return View("CreateUpdate", vm);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _gateway.Delete(id);
                return RedirectToAction("Update", "GlobalGoal", new { id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["toast"] = "Kunne ikke slette den valgte AudioVideo. Prøv igen eller kontakt administrator";
                return RedirectToAction("Update", new { id });
            }
        }
    }
}