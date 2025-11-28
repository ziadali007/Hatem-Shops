using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services.Abstractions
{
    public interface IChargerService
    {
        Task<IEnumerable<ChargerResultDto>> GetAllChargersAsync();
        Task<ChargerResultDto> GetChargerByNameAsync(string name);
        Task CreateChargerAsync(AddChargerResultDto chargerDto);
        Task UpdateChargerAsync(AddChargerResultDto chargerDto);
        Task DeleteChargerAsync(int id);
    }
}
