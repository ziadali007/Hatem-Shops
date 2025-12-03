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
    public class CableController : ControllerBase
    {
        private readonly string _adminPassword;
        private readonly IServiceManager serviceManager;
        public CableController(IOptions<AdminSettings> adminSettingsOptions, IServiceManager service)
        {
            _adminPassword = adminSettingsOptions.Value.Password;
            serviceManager = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCables()
        {
            var cables = await serviceManager.CableService.GetAllCablesAsync();
            if (cables == null || !cables.Any()) return NotFound("No cables found.");
            return Ok(cables);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetCableByName(string name)
        {
           
            var cable = await serviceManager.CableService.GetCableByNameAsync(name);
            if (cable == null) return NotFound($"Cable with name '{name}' not found.");
            return Ok(cable);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCable([FromBody] AddCableResultDto cableDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (cableDto == null) return BadRequest("Cable data is null.");
            await serviceManager.CableService.CreateCableAsync(cableDto);
            return Ok(cableDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCable([FromBody] CableResultDto cableDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (cableDto == null) return BadRequest("Cable data is null.");
            await serviceManager.CableService.UpdateCableAsync(cableDto);
            return Ok(cableDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCable(int id, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            await serviceManager.CableService.DeleteCableAsync(id);
            return Ok($"Cable with ID '{id}' has been deleted.");
        }
    }
}
