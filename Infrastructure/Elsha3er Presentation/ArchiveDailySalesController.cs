using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using Elsha3er_Services.Abstractions;

namespace Elsha3er_Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchiveDailySalesController : ControllerBase
    {
        private readonly string _adminPassword;
        private readonly IServiceManager serviceManager;
        public ArchiveDailySalesController(IOptions<AdminSettings> adminSettingsOptions, IServiceManager service)
        {
            _adminPassword = adminSettingsOptions.Value.Password;
            serviceManager = service;
        }
        [HttpPost]
        public async Task<IActionResult> ArchiveToday()
        {
            var archive = await serviceManager.ArchiveDailySalesService.ArchiveAsync();
            if (archive == null || !archive.Any())
                return NotFound("No sales found to archive for today.");
            return Ok(archive);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArchivedSales([FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");


            var archivedSales = await serviceManager.ArchiveDailySalesService.GetArchiveGroupedAsync();

            if (archivedSales == null || !archivedSales.Any())
                return NotFound("No archived sales found.");

            return Ok(archivedSales);
        }


        [HttpGet("{date}")]
        public async Task<IActionResult> GetArchivedSalesByDate(DateTime date, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            var archivedSales = await serviceManager.ArchiveDailySalesService.GetArchiveByDateAsync(date);
            if (archivedSales == null || !archivedSales.Any())
                return NotFound($"No archived sales found for date '{date.ToShortDateString()}'.");
            return Ok(archivedSales);
        }

    }
}
