using BusinessLayer;
using WebApplication1.Infrastructures.Services;

namespace WebApplication1.Infrastructures
{
    public class ServiceManager
    {
        DataManager _dataManager;
        private DoctorsService _doctorsService;
        private ProviderService _providerService;
        private TradeNameservice _TradeNameervice;
        private PreparationService _preparationService;

        public ServiceManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _doctorsService = new DoctorsService(_dataManager);
            _providerService = new ProviderService(_dataManager);
            _TradeNameervice = new TradeNameservice(_dataManager);
            _preparationService = new PreparationService(_dataManager);
        }
        public DoctorsService Doctors { get { return _doctorsService; } }
        public ProviderService Providers { get { return _providerService; } }
        public TradeNameservice TradeName { get { return _TradeNameervice; } }
        public PreparationService Preparation { get { return _preparationService; } }
    }

}
