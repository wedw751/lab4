    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessLayer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApplication1.Infrastructures;
    using WebApplication1.Models.ProviderEntities;

        namespace WebApplication1.Controllers
        {
        [Authorize]
        public class ProviderController : Controller
        {
            private DataManager _dataManager;
            private ServiceManager _serviceManage;

            public ProviderController(DataManager dataManager)
            {
                _dataManager = dataManager;
                _serviceManage = new ServiceManager(_dataManager);
            }

            public IActionResult Index()
            {
                return View(_serviceManage.Providers.GetAllProviders());
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(ProviderVm providerVm)
            {
                ModelState.Remove("Id");
                if (!ModelState.IsValid)
                {
                    return View(providerVm);
                }

                _serviceManage.Providers.CreateProvider(providerVm);
                return RedirectToAction("Index");
            }

            [HttpGet]
            public IActionResult Edit(int Id)
            {
                return View(_serviceManage.Providers.GetProviderById(Id));
            }

            [HttpPost]
            public IActionResult Edit(ProviderVm providerVm)
            {
                if (!ModelState.IsValid)
                {
                    return View(providerVm);
                }

                _serviceManage.Providers.EditProvider(providerVm);
                return RedirectToAction("Index");
            }

            [HttpGet]
            [ActionName("Delete")]
            public IActionResult ConfirmDelete(int? Id)
            {
                if (Id != null)
                {
                    var model = _serviceManage.Providers.GetProviderById(Id);
                    if (model != null)
                    {
                        var modelVm = new ProviderVm
                        {
                            Id = model.Id,
                            Name = model.Name,
                            Address = model.Address,
                            Telephone = model.Telephone,
                        };
                        return View(modelVm);
                    }
                }
                return NotFound();
            }

            [HttpPost]
            public IActionResult Delete(int? Id)
            {
                if (Id != null)
                {
                    _serviceManage.Providers.DeleteProvider(Id.Value);
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
        }
    }

