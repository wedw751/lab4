using BusinessLayer.Interfaces.BusinessLayer.interfaces;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class DataManager
    {
        private IBaseRepository<Provider> _providerRepository;
        private IBaseRepository<Doctor> _doctorRepository;
        private IBaseRepository<NameTrade> _tradeNameRepository;
        private IBaseExtraRepository<Preparation> _preparationRepository;

        public DataManager(IBaseRepository<Provider> providerRepository,
            IBaseRepository<Doctor> doctorRepository,
            IBaseRepository<NameTrade> tradeNameRepository,
            IBaseExtraRepository<Preparation> preparationRepository)
        {
            _providerRepository = providerRepository;
            _doctorRepository = doctorRepository;
            _tradeNameRepository = tradeNameRepository;
            _preparationRepository = preparationRepository;
        }

        public IBaseRepository<Provider> Providers { get { return _providerRepository; } }
        public IBaseRepository<Doctor> Doctors { get { return _doctorRepository; } }
        public IBaseRepository<NameTrade> TradeName { get { return _tradeNameRepository; } }
        public IBaseExtraRepository<Preparation> Preparations { get { return _preparationRepository; } }
    }
}
