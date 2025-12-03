using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Services.Abstractions
{
    public interface IScreenService
    {
        Task<IEnumerable<ScreenResultDto>> GetAllScreensAsync();
        Task<IEnumerable<ScreenResultDto>> GetScreenByNameAsync(string name);
        Task CreateScreenAsync(AddScreenResultDto screenDto);
        Task UpdateScreenAsync(ScreenResultDto screenDto);
        Task DeleteScreenAsync(int id);
    }
}
