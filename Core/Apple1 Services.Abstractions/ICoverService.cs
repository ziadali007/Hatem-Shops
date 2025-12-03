using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services.Abstractions
{
    public interface ICoverService
    {
        Task<IEnumerable<CoverResultDto>> GetAllCoversAsync();

        Task<IEnumerable<CoverResultDto>> GetCoverByNameAsync(string name);

        Task CreateCoverAsync(AddCoverResultDto coverDto);

        Task UpdateCoverAsync(CoverResultDto coverDto);

        Task DeleteCoverAsync(int id);
    }
}
