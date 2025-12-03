using Apple1_Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchController : ControllerBase
    {
        private readonly string _adminPassword;
        private readonly IServiceManager serviceManager;
        public WatchController(IOptions<AdminSettings> adminSettingsOptions, IServiceManager service)
        {
            _adminPassword = adminSettingsOptions.Value.Password;
            serviceManager = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWatches()
        {
            var watches = await serviceManager.WatchService.GetAllWatches();
            if (watches == null || !watches.Any()) return NotFound("No watches found.");
            return Ok(watches);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetWatchByName(string name)
        {
            var watches = await serviceManager.WatchService.GetWatchByNameAsync(name);
            if (watches == null || !watches.Any()) return NotFound($"No watches found with name '{name}'.");
            return Ok(watches);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWatch([FromBody] AddWatchResultDto watchDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (watchDto == null) return BadRequest("Watch data is null.");
            await serviceManager.WatchService.CreateWatchAsync(watchDto);
            return Ok(watchDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWatch([FromBody] WatchResultDto watchDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (watchDto == null) return BadRequest("Watch data is null.");
            await serviceManager.WatchService.UpdateWatchAsync(watchDto);
            return Ok(watchDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatch(int id, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            await serviceManager.WatchService.DeleteWatchAsync(id);
            return Ok($"Watch with ID '{id}' has been deleted.");
        }
    }
}
