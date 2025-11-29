using Apple1_Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchiveDailySalesController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ArchiveToday()
        {
            var archive = await serviceManager.ArchiveDailySalesService.ArchiveAsync();
            if (archive == null || !archive.Any())
                return NotFound("No sales found to archive for today.");

            return Ok(archive);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllArchivedSales()
        {
            var archivedSales = await serviceManager.ArchiveDailySalesService.GetArchiveGroupedAsync();
            if (archivedSales == null || !archivedSales.Any())
                return NotFound("No archived sales found.");
            return Ok(archivedSales);
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetArchivedSalesByDate([FromQuery] DateTime date)
        {
            var archivedSales = await serviceManager.ArchiveDailySalesService.GetArchiveByDateAsync(date);
            if (archivedSales == null || !archivedSales.Any())
                return NotFound($"No archived sales found for date '{date.ToShortDateString()}'.");
            return Ok(archivedSales);
        }

    }
}
