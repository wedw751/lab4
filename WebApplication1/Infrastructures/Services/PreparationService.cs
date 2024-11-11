using BusinessLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.PreparationEnitities;

namespace WebApplication1.Infrastructures.Services
{
    public class PreparationService
    {
        private DataManager _dataManager;
        public PreparationService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void Create(PreparationVm model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model is null");
            }

            var dbModel = GetDbModel(model);

            var provider = _dataManager.Providers.GetById(model.ProviderId);
            dbModel.Provider = provider;

            var tradeName = _dataManager.TradeName.GetById(model.TradeNameId);
            dbModel.NameTrade = tradeName;

            _dataManager.Preparations.Create(dbModel);
        }

        public List<PreparationVm> GetAll()
        {
            var dbModel = _dataManager.Preparations.GetAll();
            var dbModel2 = _dataManager.Preparations.GetAll().ToList();

            List<PreparationVm> doctorsList = new List<PreparationVm>();

            foreach (var item in dbModel)
            {
                doctorsList.Add(GetFromDbModel(item));
            }
            return doctorsList;
        }

        public void Edit(PreparationVm preparation)
        {
            var dbEntity = GetDbModel(preparation);

            var provider = _dataManager.Providers.GetById(preparation.ProviderId);
            dbEntity.Provider = provider;

            var tradeName = _dataManager.TradeName.GetById(preparation.TradeNameId);
            dbEntity.NameTrade = tradeName;

            _dataManager.Preparations.Update(dbEntity);
        }

        public PreparationVm GetById(int Id)
        {
            return GetFromDbModel(_dataManager.Preparations.GetById(Id));
        }

        public void Delete(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException("id is null");
            }

            _dataManager.Preparations.Delete(Id.Value);
        }

        public Preparation GetDbModel(PreparationVm model)
        {
            var dbModel = new Preparation()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
            };
            return dbModel;
        }
        public PreparationVm GetFromDbModel(Preparation dbModel)
        {
            var model = new PreparationVm()
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Description = dbModel.Description,
                Price = dbModel.Price,
                TradeNameDisp = dbModel?.NameTrade?.Name,
                ProviderDisp = dbModel?.Provider?.Name,
            };
            return model;
        }
    }
}

