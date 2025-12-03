using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Services.Abstractions
{
    public interface ICableServices
    {
        Task<IEnumerable<CableResultDto>> GetAllCablesAsync();
        Task<IEnumerable<CableResultDto>> GetCableByNameAsync(string name);
        Task CreateCableAsync(AddCableResultDto cableDto);
        Task UpdateCableAsync( CableResultDto cableDto);
        Task DeleteCableAsync(int id);
    }
}
