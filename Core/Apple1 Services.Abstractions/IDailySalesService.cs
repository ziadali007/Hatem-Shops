using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services.Abstractions
{
    public interface IDailySalesService
    {
        Task<IEnumerable<DailySalesResultDto>> GetAllDailySalesAsync();
        Task<DailySalesResultDto> GetDailySalesByDateAsync(DateTime date);
        Task CreateDailySalesAsync(DailySalesResultDto dailySalesDto);
        Task UpdateDailySalesAsync(DailySalesResultDto dailySalesDto);
        Task DeleteDailySalesAsync(int id);
    }
}
