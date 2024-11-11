
using BusinessLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.TradeNameEntities;

namespace WebApplication1.Infrastructures.Services
{
    public class TradeNameservice
    {
        private DataManager _dataManager;
        public TradeNameservice(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void CreateTradeName(TradeNameVm tradeName)
        {
            if (tradeName == null)
            {
                throw new ArgumentNullException("tradeName is null");
            }

            NameTrade DbTradeName = GetTradeNameDBModel(tradeName);
            _dataManager.TradeName.Create(DbTradeName);
        }

        public List<TradeNameVm> GetAllTradeName()
        {
            var _tradeName = _dataManager.TradeName.GetAll();

            List<TradeNameVm> doctorsList = new List<TradeNameVm>();

            foreach (var item in _tradeName)
            {
                doctorsList.Add(GetTradeNameVmEntity(item));
            }
            return doctorsList;
        }

        public TradeNameVm GetTradeNameById(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException("id is null");
            }

            var tradeName = _dataManager.TradeName.GetById(Id.Value);

            return GetTradeNameVmEntity(tradeName);
        }

        public void DeleteTradeName(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException("id is null");
            }

            _dataManager.TradeName.Delete(Id.Value);
        }

        public void EditTradeName(TradeNameVm tradeNameVm)
        {
            var tradeName = GetTradeNameDBModel(tradeNameVm);
            _dataManager.TradeName.Update(tradeName);
        }

        private NameTrade GetTradeNameDBModel(TradeNameVm vm)
        {
            NameTrade tradeName = new NameTrade()
            {
                Id = vm.Id,
                Name = vm.Name
            };

            return tradeName;
        }

        private TradeNameVm GetTradeNameVmEntity(NameTrade tradeName)
        {
            TradeNameVm tradeNameVm = new TradeNameVm()
            {
                Id = tradeName.Id,
                Name = tradeName.Name
            };

            return tradeNameVm;
        }
    }
}
