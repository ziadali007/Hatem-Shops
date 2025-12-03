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
    public class HeadPhoneController : ControllerBase
    {

        private readonly string _adminPassword;
        private readonly IServiceManager serviceManager;
        public HeadPhoneController(IOptions<AdminSettings> adminSettingsOptions, IServiceManager service)
        {
            _adminPassword = adminSettingsOptions.Value.Password;
            serviceManager = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHeadPhones()
        {
            var headPhones = await serviceManager.HeadPhoneService.GetAllHeadPhonesAsync();
            if (headPhones == null || !headPhones.Any()) return NotFound("No head phones found.");
            return Ok(headPhones);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetHeadPhoneByName(string name)
        {
            var headPhone = await serviceManager.HeadPhoneService.GetHeadPhonesByNameAsync(name);
            if (headPhone == null) return NotFound($"Head phone with name '{name}' not found.");
            return Ok(headPhone);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHeadPhone([FromBody] AddHeadPhoneResultDto headPhoneDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (headPhoneDto == null) return BadRequest("Head phone data is null.");
            await serviceManager.HeadPhoneService.CreateHeadPhonesAsync(headPhoneDto);
            return Ok(headPhoneDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHeadPhone([FromBody] HeadPhoneResultDto headPhoneDto, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            if (headPhoneDto == null) return BadRequest("Head phone data is null.");
            await serviceManager.HeadPhoneService.UpdateHeadPhonesAsync(headPhoneDto);
            return Ok(headPhoneDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeadPhone(int id, [FromHeader(Name = "Admin-Password")] string password)
        {
            if (password != _adminPassword)
                return StatusCode(401, "Invalid password");
            await serviceManager.HeadPhoneService.DeleteHeadPhonesAsync(id);
            return Ok($"Head phone with ID '{id}' has been deleted.");
        }
    }
}
