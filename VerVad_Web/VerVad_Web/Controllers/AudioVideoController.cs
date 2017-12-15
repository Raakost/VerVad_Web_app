using ServiceGateways.Entities;
using ServiceGateways.Facade;
using ServiceGateways.Interfaces;
using ServiceGateways.ServiceGateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerVad_Web.ViewModels.AudioVideos;

namespace VerVad_Web.Controllers
{
    public class AudioVideoController : Controller
    {
        private ILanguageServiceGateway<Language> _languageServiceGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private AudioVideoServiceGateway _gateway = (AudioVideoServiceGateway)new ServiceGatewayFacade().GetAudioVideoServiceGateway();

        [HttpGet]
        public ActionResult Create(int gg_id)
        {
            var vm = new AudioVideoCreateUpdate();
            vm.AudioVideo = new AudioVideo()
            {
                Id = gg_id
            };
            vm.Languages = _languageServiceGateway.ReadAll();
            vm.IsCreate = true;
            return View("CreateUpdate", vm);
        }

        [HttpPost]
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
                return RedirectToAction("Update", "GlobalGoal", new { id = vm.AudioVideo.Id });
            }
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var av = _gateway.Read(id);
                var vm = new AudioVideoCreateUpdate();
                vm.AudioVideo = av;
                vm.Languages = _languageServiceGateway.ReadAll();

                return View("CreateUpdate", vm);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpPost]
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
                _gateway.Delete(id);
                return RedirectToAction("Update", "GlobalGoal", new { id });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", e.Message);
                return RedirectToAction("Update", new { id });
            }
        }
    }
}