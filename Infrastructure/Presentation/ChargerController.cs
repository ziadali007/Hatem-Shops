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
    public class ChargerController : ControllerBase
    {
        private readonly string _adminPassword;
        private readonly IServiceManager serviceManager;
        public ChargerController(IOptions<AdminSettings> adminSettingsOptions, IServiceManager service)
        {
            _adminPassword = adminSettingsOptions.Value.Password;
            serviceManager = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllChargers()
        {
            var chargers = await serviceManager.ChargerService.GetAllChargersAsync();
            if (chargers == null || !chargers.Any()) return NotFound("No chargers found.");
            return Ok(chargers);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetChargerByName(string name)
        {
            var charger = await serviceManager.ChargerService.GetChargerByNameAsync(name);
            if (charger == null) return NotFound($"Charger with name '{name}' not found.");
            return Ok(charger);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharger([FromBody] AddChargerResultDto chargerDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (chargerDto == null) return BadRequest("Charger data is null.");
            await serviceManager.ChargerService.CreateChargerAsync(chargerDto);
            return Ok(chargerDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharger([FromBody] ChargerResultDto chargerDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (chargerDto == null) return BadRequest("Charger data is null.");
            await serviceManager.ChargerService.UpdateChargerAsync(chargerDto);
            return Ok(chargerDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharger(int id, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            await serviceManager.ChargerService.DeleteChargerAsync(id);
            return Ok($"Charger with ID '{id}' has been deleted.");
        }
    }
}
