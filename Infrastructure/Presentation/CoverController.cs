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
    public class CoverController : ControllerBase
    {
        private readonly string _adminPassword;
        private readonly IServiceManager serviceManager;
        public CoverController(IOptions<AdminSettings> adminSettingsOptions, IServiceManager service)
        {
            _adminPassword = adminSettingsOptions.Value.Password;
            serviceManager = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCovers()
        {
            var covers = await serviceManager.CoverService.GetAllCoversAsync();
            if (covers == null || !covers.Any()) return NotFound("No covers found.");
            return Ok(covers);
        }

        [HttpGet("{Name}")]

        public async Task<IActionResult> GetCoverByName(string name)
        {
            var cover = await serviceManager.CoverService.GetCoverByNameAsync(name);
            if (cover == null) return NotFound($"Cover with name '{name}' not found.");
            return Ok(cover);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCover([FromBody] AddCoverResultDto coverDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (coverDto == null) return BadRequest("Cover data is null.");
            await serviceManager.CoverService.CreateCoverAsync(coverDto);
            return Ok(coverDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCover([FromBody] CoverResultDto coverDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (coverDto == null) return BadRequest("Cover data is null.");
            await serviceManager.CoverService.UpdateCoverAsync(coverDto);
            return Ok(coverDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCover(int id, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            await serviceManager.CoverService.DeleteCoverAsync(id);
            return Ok($"Cover with ID '{id}' has been deleted.");
        }
    }
}
