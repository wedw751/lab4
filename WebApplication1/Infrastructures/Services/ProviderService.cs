using BusinessLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.ProviderEntities;

namespace WebApplication1.Infrastructures.Services
{
    public class ProviderService
    {
        private DataManager _dataManager;
        public ProviderService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void CreateProvider(ProviderVm provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider is null");
            }

            Provider DbProvider = GetProviderDBModel(provider);
            _dataManager.Providers.Create(DbProvider);
        }

        public List<ProviderVm> GetAllProviders()
        {
            var _roviders = _dataManager.Providers.GetAll();

            List<ProviderVm> providersList = new List<ProviderVm>();

            foreach (var item in _roviders)
            {
                providersList.Add(GetProviderVmEntity(item));
            }
            return providersList;
        }

        public ProviderVm GetProviderById(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException("id is null");
            }

            var provider = _dataManager.Providers.GetById(Id.Value);

            return GetProviderVmEntity(provider);
        }

        public void DeleteProvider(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException("id is null");
            }

            _dataManager.Providers.Delete(Id.Value);
        }

        public void EditProvider(ProviderVm ProviderVm)
        {
            var provider = GetProviderDBModel(ProviderVm);
            _dataManager.Providers.Update(provider);
        }

        private Provider GetProviderDBModel(ProviderVm vm)
        {
            Provider provider = new Provider()
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
                Telephone = vm.Telephone,
            };

            return provider;
        }

        private ProviderVm GetProviderVmEntity(Provider provider)
        {
            ProviderVm ProviderVm = new ProviderVm()
            {
                Id = provider.Id,
                Name = provider.Name,
                Address = provider.Address,
                Telephone = provider.Telephone,
            };

            return ProviderVm;
        }
    }
}
