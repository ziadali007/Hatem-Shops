using Apple1_Domain.Contracts;
using Apple1_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class ArchiveDailySalesService : IArchiveDailySalesService
    {
        private readonly Apple1DbContext _apple1;
        public ArchiveDailySalesService(Apple1DbContext apple1DbContext)
        {
            _apple1 = apple1DbContext;
        }
        public async Task ArchiveAsync()
        {
            var dailySales = _apple1.Set<DailySales>().AsNoTracking().ToList();
            if (!dailySales.Any()) return;
            var archives = dailySales.Select(s => new DailySalesArchive
            {
                ProductId = s.ProductId,
                Quantity = s.Quantity,
                Price = s.Price,
                Total = s.Quantity * s.Price,
                SaleDate = DateTime.UtcNow.Date
            }).ToList();

            await _apple1.Set<DailySalesArchive>().AddRangeAsync(archives);
            _apple1.Set<DailySales>().RemoveRange(dailySales);
        }
    }
}
