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
    public class HeadPhoneController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHeadPhones()
        {
            var headPhones = await serviceManager.HeadPhoneService.GetAllHeadPhonesAsync();
            if (headPhones == null || !headPhones.Any()) return NotFound("No head phones found.");
            return Ok(headPhones);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetHeadPhoneByName([FromQuery] string name)
        {
            var headPhone = await serviceManager.HeadPhoneService.GetHeadPhonesByNameAsync(name);
            if (headPhone == null) return NotFound($"Head phone with name '{name}' not found.");
            return Ok(headPhone);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHeadPhone([FromBody] AddHeadPhoneResultDto headPhoneDto)
        {
            if (headPhoneDto == null) return BadRequest("Head phone data is null.");
            await serviceManager.HeadPhoneService.CreateHeadPhonesAsync(headPhoneDto);
            return Ok(headPhoneDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHeadPhone([FromBody] AddHeadPhoneResultDto headPhoneDto)
        {
            if (headPhoneDto == null) return BadRequest("Head phone data is null.");
            await serviceManager.HeadPhoneService.UpdateHeadPhonesAsync(headPhoneDto);
            return Ok(headPhoneDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeadPhone(int id)
        {
            await serviceManager.HeadPhoneService.DeleteHeadPhonesAsync(id);
            return Ok($"Head phone with ID '{id}' has been deleted.");
        }
    }
}
