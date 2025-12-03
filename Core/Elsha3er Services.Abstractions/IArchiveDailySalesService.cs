using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Services.Abstractions
{
    public interface IArchiveDailySalesService
    {
        Task<IEnumerable<DailySalesArchiveResultDto>> ArchiveAsync();
        Task<IEnumerable<DailySalesArchiveResultDto>> GetArchiveByDateAsync(DateTime date);
        Task<IEnumerable<ArchiveGroupDto>> GetArchiveGroupedAsync();
    }
}
