using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services.Abstractions
{
    public interface IScreenService
    {
        Task<IEnumerable<ScreenResultDto>> GetAllScreensAsync();
        Task<ScreenResultDto> GetScreenByNameAsync(string name);
        Task CreateScreenAsync(AddScreenResultDto screenDto);
        Task UpdateScreenAsync(AddScreenResultDto screenDto);
        Task DeleteScreenAsync(int id);
    }
}
