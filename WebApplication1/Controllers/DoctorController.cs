
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessLayer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApplication1.Infrastructures;
    using WebApplication1.Models.DoctorEntities;

        namespace WebApplication1.Controllers
        {
    
        [Authorize]
        public class DoctorController : Controller
        {
            private DataManager _dataManager;
            private ServiceManager _serviceManage;

            public DoctorController(DataManager dataManager)
            {
                _dataManager = dataManager;
                _serviceManage = new ServiceManager(_dataManager);
            }

            public IActionResult Index()
            {
                return View(_serviceManage.Doctors.GetAllDoctors());
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(DoctorVm doctorVm)
            {
                ModelState.Remove("Id");
                if (!ModelState.IsValid)
                {
                    return View(doctorVm);
                }

                _serviceManage.Doctors.CreateDoctor(doctorVm);
                return RedirectToAction("Index");
            }

            [HttpGet]
            public IActionResult Edit(int Id)
            {
                return View(_serviceManage.Doctors.GetDoctorById(Id));
            }

            [HttpPost]
            public IActionResult Edit(DoctorVm doctorVm)
            {
                if (!ModelState.IsValid)
                {
                    return View(doctorVm);
                }

                _serviceManage.Doctors.EditDoctor(doctorVm);
                return RedirectToAction("Index");
            }

            [HttpGet]
            [ActionName("Delete")]
            public IActionResult ConfirmDelete(int? Id)
            {
                if (Id != null)
                {
                    var model = _serviceManage.Doctors.GetDoctorById(Id);
                    if (model != null)
                    {
                        var modelVm = new DoctorVm
                        {
                            Id = model.Id,
                            Name = model.Name,
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
                    _serviceManage.Doctors.DeleteDoctor(Id.Value);
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
        }
    }

