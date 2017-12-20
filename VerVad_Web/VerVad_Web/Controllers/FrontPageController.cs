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
using VerVad_Web.ViewModels.FrontPageUpdate;

namespace VerVad_Web.Controllers
{
    [LoginRequired]
    public class FrontPageController : Controller
    {
        private readonly IFrontPageServiceGateway<FrontPage, int> _frontPageServiceGateway = new ServiceGatewayFacade().GetFrontPageServiceGateway();
        private readonly ILanguageServiceGateway<Language> _languageServiceGateway = new ServiceGatewayFacade().GetLanguageServiceGateway();
        private readonly CloudinaryServiceGateway _cloudinaryServiceGateway = new CloudinaryServiceGateway();

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var fp = _frontPageServiceGateway.Read(id);
                var vm = new FrontPageUpdateViewModel();
                vm.Frontpage = fp;
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
        public ActionResult Update(FrontPageUpdateViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fp = _frontPageServiceGateway.Update(vm.Frontpage);
                    TempData["toast"] = "Dine ændringer er gemt!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Fejl i model", "Modellen er ugyldig, prøv igen!");
                    return View("Update", vm.Frontpage);
                }
            }
            catch (Exception e)
            {

                ModelState.AddModelError("error", e.Message);
                return View("Update", vm.Frontpage);
            }
        }
    }
}