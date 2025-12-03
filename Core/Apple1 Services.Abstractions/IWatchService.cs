using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services.Abstractions
{
    public interface IWatchService
    {
        Task<IEnumerable<WatchResultDto>> GetAllWatches();
        Task<IEnumerable<WatchResultDto>> GetWatchByNameAsync(string name);

        Task CreateWatchAsync(AddWatchResultDto watchDto);

        Task UpdateWatchAsync(WatchResultDto watchDto);
        Task DeleteWatchAsync(int id);
    }
}
