using Microsoft.AspNetCore.Mvc;
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
    public class SaleController(IServiceManager serviceManager) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetTodaySales()
        {
            var sales = await serviceManager.SaleService.GetTodaySalesAsync();
            if (sales == null || !sales.Any()) return NotFound("No sales found.");
            return Ok(sales);
        }

        //[HttpGet("GetTotalAmount")]
        //public async Task<IActionResult> GetSaleTotalAmount()
        //{
        //    var sale = await serviceManager.SaleService.GetTodayTotalAmountAsync();
        //    if (sale == null) return NotFound($"Sale Amount not found.");
        //    return Ok(sale);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] AddSaleResultDto saleDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (saleDto == null) return BadRequest("Sale data is null.");
            await serviceManager.SaleService.AddSaleAsync(saleDto);
            return Ok(saleDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            await serviceManager.SaleService.DeleteSaleAsync(id);
            return Ok($"Sale with ID '{id}' has been deleted.");
        }

    }
}
