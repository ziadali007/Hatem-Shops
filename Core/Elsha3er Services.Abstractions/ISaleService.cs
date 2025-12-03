using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Services.Abstractions
{
    public interface ISaleService
    {
        Task AddSaleAsync(AddSaleResultDto dto);
        Task<IEnumerable<SaleResultDto>> GetTodaySalesAsync();
        Task DeleteSaleAsync(int id);
        //Task<decimal> GetTodayTotalAmountAsync();
    }
}
