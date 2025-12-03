using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Services.Abstractions
{
    public interface IChargerService
    {
        Task<IEnumerable<ChargerResultDto>> GetAllChargersAsync();
        Task<IEnumerable<ChargerResultDto>> GetChargerByNameAsync(string name);
        Task CreateChargerAsync(AddChargerResultDto chargerDto);
        Task UpdateChargerAsync(ChargerResultDto chargerDto);
        Task DeleteChargerAsync(int id);
    }
}
