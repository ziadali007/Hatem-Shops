using Apple1_Domain.Contracts;
using Apple1_Domain.Exceptions;
using Apple1_Domain.Models;
using Apple1_Services.Abstractions;
using AutoMapper;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services
{
    public class SaleService(IMapper mapper,IUnitOfWork unitOfWork) : ISaleService
    {
        public async Task<IEnumerable<SaleResultDto>> GetTodaySalesAsync()
        {
            var today = DateTime.UtcNow.Date;
            var sales= await unitOfWork.GetRepository<Sale>()
                                .FindAsync(s => s.Time.Date == today);
            var result = mapper.Map<IEnumerable<SaleResultDto>>(sales);
            return result;
        }

        public async Task<decimal> GetTodayTotalAmountAsync()
        {
            var amounts = await unitOfWork.GetRepository<Sale>()
                                .SumAsync(s => s.Time.Date == DateTime.UtcNow.Date, s => s.Price * s.Quantity);
            return amounts;
        }
        public async Task AddSaleAsync(AddSaleResultDto dto)
        {
            var sale = mapper.Map<Sale>(dto);
            await unitOfWork.GetRepository<Sale>().AddAsync(sale);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSaleAsync(int id)
        {
            var sale =await unitOfWork.GetRepository<Sale>().GetAsync(s => s.Id == id);
            if (sale == null) throw new SaleNotFoundException("Sale Not Found");
            unitOfWork.GetRepository<Sale>().Delete(sale);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
