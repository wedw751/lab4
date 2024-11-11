using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DoctorEntities;
using WebApplication1.Models.ProviderEntities;
using WebApplication1.Infrastructures;
using WebApplication1.Models.PreparationEnitities;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class PreparationController : Controller
    {
        private DataManager _dataManager;
        private ServiceManager _serviceManage;

        public PreparationController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _serviceManage = new ServiceManager(_dataManager);
        }

        public IActionResult Index()
        {
            return View(_serviceManage.Preparation.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var provider = _serviceManage.Providers.GetAllProviders();
            var tradeName = _serviceManage.TradeName.GetAllTradeName();

            ViewBag.Provider = provider;
            ViewBag.TradeName = tradeName;

            return View();
        }

        [HttpPost]
        public IActionResult Create(PreparationVm model)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid || model.ProviderId == 0 || model.TradeNameId == 0)
            {
                var provider = _serviceManage.Providers.GetAllProviders();
                var tradeName = _serviceManage.TradeName.GetAllTradeName();

                ViewBag.Provider = provider;
                ViewBag.TradeName = tradeName;

                return View(model);
            }

            _serviceManage.Preparation.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var provider = _serviceManage.Providers.GetAllProviders();
            var tradeName = _serviceManage.TradeName.GetAllTradeName();

            ViewBag.Provider = provider;
            ViewBag.TradeName = tradeName;

            //selected="@(item.Id == Model?.ProviderId ? "selected" : "")"

            return View(_serviceManage.Preparation.GetById(Id));
        }

        [HttpPost]
        public IActionResult Edit(PreparationVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _serviceManage.Preparation.Edit(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? Id)
        {
            if (Id != null)
            {
                var model = _serviceManage.Preparation.GetById(Id.Value);
                if (model != null)
                {
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                _serviceManage.Preparation.Delete(Id.Value);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
