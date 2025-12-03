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
    public class ScreenController : ControllerBase
    {
        private readonly string _adminPassword;
        private readonly IServiceManager serviceManager;
        public ScreenController(IOptions<AdminSettings> adminSettingsOptions, IServiceManager service)
        {
            _adminPassword = adminSettingsOptions.Value.Password;
            serviceManager = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllScreens()
        {
            var screens =await serviceManager.ScreenService.GetAllScreensAsync();
            if (screens == null || !screens.Any()) return NotFound("No screens found.");
            return Ok(screens);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetScreenByName( string name)
        {
            var screen = await serviceManager.ScreenService.GetScreenByNameAsync(name);
            if (screen == null) return NotFound($"Screen with name '{name}' not found.");
            return Ok(screen);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScreen([FromBody] AddScreenResultDto screenDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (screenDto == null) return BadRequest("Screen data is null.");
            await serviceManager.ScreenService.CreateScreenAsync(screenDto);
            return Ok(screenDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateScreen([FromBody] ScreenResultDto screenDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (screenDto == null ) return BadRequest("Screen data is null or Not Found.");
            await serviceManager.ScreenService.UpdateScreenAsync(screenDto);
            return Ok(screenDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreen(int id, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            await serviceManager.ScreenService.DeleteScreenAsync(id);
            return Ok($"Screen with ID '{id}' has been deleted.");
        }
    }
}
