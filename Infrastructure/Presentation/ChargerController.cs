using Apple1_Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
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
    public class ChargerController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllChargers()
        {
            var chargers = await serviceManager.ChargerService.GetAllChargersAsync();
            if (chargers == null || !chargers.Any()) return NotFound("No chargers found.");
            return Ok(chargers);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetChargerByName([FromQuery] string name)
        {
            var charger = await serviceManager.ChargerService.GetChargerByNameAsync(name);
            if (charger == null) return NotFound($"Charger with name '{name}' not found.");
            return Ok(charger);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharger([FromBody] AddChargerResultDto chargerDto)
        {
            if (chargerDto == null) return BadRequest("Charger data is null.");
            await serviceManager.ChargerService.CreateChargerAsync(chargerDto);
            return Ok(chargerDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharger([FromBody] AddChargerResultDto chargerDto)
        {
            if (chargerDto == null) return BadRequest("Charger data is null.");
            await serviceManager.ChargerService.UpdateChargerAsync(chargerDto);
            return Ok(chargerDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharger(int id)
        {
            await serviceManager.ChargerService.DeleteChargerAsync(id);
            return Ok($"Charger with ID '{id}' has been deleted.");
        }
    }
}
