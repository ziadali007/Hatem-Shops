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
    public class CoverController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCovers()
        {
            var covers = await serviceManager.CoverService.GetAllCoversAsync();
            if (covers == null || !covers.Any()) return NotFound("No covers found.");
            return Ok(covers);
        }

        [HttpGet("{Name}")]

        public async Task<IActionResult> GetCoverByName([FromQuery] string name)
        {
            var cover = await serviceManager.CoverService.GetCoverByNameAsync(name);
            if (cover == null) return NotFound($"Cover with name '{name}' not found.");
            return Ok(cover);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCover([FromBody] AddCoverResultDto coverDto)
        {
            if (coverDto == null) return BadRequest("Cover data is null.");
            await serviceManager.CoverService.CreateCoverAsync(coverDto);
            return Ok(coverDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCover([FromBody] AddCoverResultDto coverDto)
        {
            if (coverDto == null) return BadRequest("Cover data is null.");
            await serviceManager.CoverService.UpdateCoverAsync(coverDto);
            return Ok(coverDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCover(int id)
        {
            await serviceManager.CoverService.DeleteCoverAsync(id);
            return Ok($"Cover with ID '{id}' has been deleted.");
        }
    }
}
