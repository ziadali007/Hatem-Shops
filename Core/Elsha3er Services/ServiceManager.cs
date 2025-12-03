using Elsha3er_Domain.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsha3er_Presistence.Data;
using Elsha3er_Services.Abstractions;
using Elsha3er_Services;

namespace Apple1_Services
{
    public class ServiceManager(IMapper mapper,IUnitOfWork unitOfWork,Apple1DbContext apple1) : IServiceManager
    {
        public IArchiveDailySalesService ArchiveDailySalesService { get; } = new ArchiveDailySalesService(apple1, unitOfWork);

        public IChargerService ChargerService { get; } = new ChargerService(mapper,unitOfWork);

        public ICableServices CableService { get; } = new CableService(mapper,unitOfWork);

        public IHeadPhonesServices HeadPhoneService { get; } = new HeadPhoneService(mapper, unitOfWork);

        public IOthersService OthersService { get; } = new OthersService(mapper, unitOfWork);

        public IScreenService ScreenService { get; } = new ScreenService(mapper, unitOfWork);
        public IWatchService WatchService { get; } = new WatchService(mapper, unitOfWork);

        public ICoverService CoverService { get; } = new CoverService(mapper, unitOfWork);

        public ISaleService SaleService { get; } = new SaleService(mapper, unitOfWork);
    }
}
