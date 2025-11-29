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
    public class CableController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCables()
        {
            var cables = await serviceManager.CableService.GetAllCablesAsync();
            if (cables == null || !cables.Any()) return NotFound("No cables found.");
            return Ok(cables);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetCableByName([FromQuery] string name)
        {
            var cable = await serviceManager.CableService.GetCableByNameAsync(name);
            if (cable == null) return NotFound($"Cable with name '{name}' not found.");
            return Ok(cable);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCable([FromBody] AddCableResultDto cableDto)
        {
            if (cableDto == null) return BadRequest("Cable data is null.");
            await serviceManager.CableService.CreateCableAsync(cableDto);
            return Ok(cableDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCable([FromBody] AddCableResultDto cableDto)
        {
            if (cableDto == null) return BadRequest("Cable data is null.");
            await serviceManager.CableService.UpdateCableAsync(cableDto);
            return Ok(cableDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCable(int id)
        {
            await serviceManager.CableService.DeleteCableAsync(id);
            return Ok($"Cable with ID '{id}' has been deleted.");
        }
    }
}
