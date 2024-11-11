using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructures;
using WebApplication1.Models.TradeNameEntities;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class TradeNameController : Controller
    {
        private DataManager _dataManager;
        private ServiceManager _serviceManage;

        public TradeNameController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _serviceManage = new ServiceManager(_dataManager);
        }

        public IActionResult Index()
        {
            return View(_serviceManage.TradeName.GetAllTradeName());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TradeNameVm tradeNameVm)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View(tradeNameVm);
            }

            _serviceManage.TradeName.CreateTradeName(tradeNameVm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(_serviceManage.TradeName.GetTradeNameById(Id));
        }

        [HttpPost]
        public IActionResult Edit(TradeNameVm tradeNameVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tradeNameVm);
            }

            _serviceManage.TradeName.EditTradeName(tradeNameVm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? Id)
        {
            if (Id != null)
            {
                var model = _serviceManage.TradeName.GetTradeNameById(Id);
                if (model != null)
                {
                    var modelVm = new TradeNameVm
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
                _serviceManage.TradeName.DeleteTradeName(Id.Value);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}

