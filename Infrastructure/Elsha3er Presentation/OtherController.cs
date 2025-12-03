using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsha3er_Services.Abstractions;

namespace Elsha3er_Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtherController : ControllerBase
    {
        private readonly string _adminPassword;
        private readonly IServiceManager serviceManager;
        public OtherController(IOptions<AdminSettings> adminSettingsOptions, IServiceManager service)
        {
            _adminPassword = adminSettingsOptions.Value.Password;
            serviceManager = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOthers()
        {
            var others = await serviceManager.OthersService.GetAllOthersAsync();
            if (others == null || !others.Any()) return NotFound("No other items found.");
            return Ok(others);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetOtherByName(string name)
        {
            var other = await serviceManager.OthersService.GetOtherByNameAsync(name);
            if (other == null) return NotFound($"Other item with name '{name}' not found.");
            return Ok(other);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOther([FromBody] AddOthersResultDto otherDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (otherDto == null) return BadRequest("Other item data is null.");
            await serviceManager.OthersService.CreateOtherAsync(otherDto);
            return Ok(otherDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOther([FromBody] OthersResultDto otherDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (otherDto == null) return BadRequest("Other item data is null.");
            await serviceManager.OthersService.UpdateOtherAsync(otherDto);
            return Ok(otherDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOther(int id, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            await serviceManager.OthersService.DeleteOtherAsync(id);
            return Ok($"Other item with ID '{id}' has been deleted.");
        }
    }
}
