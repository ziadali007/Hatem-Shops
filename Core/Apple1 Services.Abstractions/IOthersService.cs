using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services.Abstractions
{
    public interface IOthersService
    {
        Task<IEnumerable<OthersResultDto>> GetAllOthersAsync();
        Task<OthersResultDto> GetOtherByNameAsync(string name);
        Task CreateOtherAsync(AddOthersResultDto otherDto);
        Task UpdateOtherAsync(AddOthersResultDto otherDto);
        Task DeleteOtherAsync(int id);
    }
}
