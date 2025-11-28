using Apple1_Domain.Contracts;
using Apple1_Domain.Models;
using Apple1_Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Shared;
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
        private readonly IUnitOfWork _context;
        public ArchiveDailySalesService(Apple1DbContext apple1DbContext, IUnitOfWork unitOfWork)
        {
            _apple1 = apple1DbContext;
            _context = unitOfWork;
        }

        public async Task<IEnumerable<DailySalesArchiveResultDto>> ArchiveAsync()
        {
            var today = DateTime.UtcNow.Date;

            // 1. Get all today's sales
            var todaysSales = await _apple1.Sales
                .Where(s => s.Time.Date == today)
                .ToListAsync();

            if (!todaysSales.Any())
                return Enumerable.Empty<DailySalesArchiveResultDto>();

            var archivedDtos = new List<DailySalesArchiveResultDto>();

            // 2. Archive each sale
            foreach (var sale in todaysSales)
            {
                var archive = new DailySalesArchive
                {
                    ProductName = sale.ProductName,
                    Quantity = sale.Quantity,
                    Price = sale.Price,
                    Total = sale.Quantity * sale.Price,
                    ArchivedDate = DateTime.UtcNow
                };

                await _apple1.dailySalesArchives.AddAsync(archive);

                archivedDtos.Add(new DailySalesArchiveResultDto
                {
                    ProductName = archive.ProductName,
                    Quantity = archive.Quantity,
                    Price = archive.Price,
                    Total = archive.Total,
                    ArchivedDate = archive.ArchivedDate
                });
            }

            // 3. Save archive entries
            await _context.SaveChangesAsync();

            // 4. Delete today’s sales after archiving
            _apple1.Sales.RemoveRange(todaysSales);

            // 5. Commit final transaction
            await _context.SaveChangesAsync();

            return archivedDtos;

        }

        public async Task<IEnumerable<DailySalesArchiveResultDto>> GetArchiveByDateAsync(DateTime date)
        {
            var d = date.Date;
            var list=await _apple1.dailySalesArchives
                .Where(a => a.ArchivedDate.Date == d)
                .OrderByDescending(a => a.ArchivedDate)
                .ToListAsync();

            var result = list.Select(a => new DailySalesArchiveResultDto
            {
                ProductName = a.ProductName,
                Quantity = a.Quantity,
                Price = a.Price,
                Total = a.Total,
                ArchivedDate = a.ArchivedDate
            });

            return result;
        }

        public async Task<IEnumerable<ArchiveGroupDto>> GetArchiveGroupedAsync()
        {
            var groups = await _apple1.dailySalesArchives
            .GroupBy(a => a.ArchivedDate.Date)
            .Select(g => new ArchiveGroupDto
            {
                Date = g.Key,
                TotalQuantity = g.Sum(x => x.Quantity),
                TotalAmount = g.Sum(x => x.Total),
                Items = g.Select(x => new ArchiveItemDto
                {
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Total = x.Total
                }).ToList()
            })
            .OrderByDescending(x => x.Date)
            .ToListAsync();

            return groups;
        }
    }
}
