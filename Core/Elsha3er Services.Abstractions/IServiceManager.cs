using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Services.Abstractions
{
    public interface IServiceManager
    {
        IArchiveDailySalesService ArchiveDailySalesService { get; }
        IChargerService ChargerService { get; }
        ICableServices CableService { get; }
        IHeadPhonesServices HeadPhoneService { get; }
        IOthersService OthersService { get; }
        IScreenService ScreenService { get; }
        IWatchService WatchService { get; }
        ICoverService CoverService { get; }
        ISaleService SaleService { get; }

    }
}
