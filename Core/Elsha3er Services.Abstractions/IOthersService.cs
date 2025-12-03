using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Services.Abstractions
{
    public interface IOthersService
    {
        Task<IEnumerable<OthersResultDto>> GetAllOthersAsync();
        Task<IEnumerable<OthersResultDto>> GetOtherByNameAsync(string name);
        Task CreateOtherAsync(AddOthersResultDto otherDto);
        Task UpdateOtherAsync(OthersResultDto otherDto);
        Task DeleteOtherAsync(int id);
    }
}
