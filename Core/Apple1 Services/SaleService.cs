using Apple1_Domain.Contracts;
using Apple1_Domain.Exceptions;
using Apple1_Domain.Models;
using Apple1_Services.Abstractions;
using AutoMapper;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services
{
    public class SaleService(IMapper mapper,IUnitOfWork unitOfWork) : ISaleService
    {
        public async Task<IEnumerable<SaleResultDto>> GetTodaySalesAsync()
        {
            var today = DateTime.UtcNow.Date;
            var sales= await unitOfWork.GetRepository<Sale>()
                                .FindAsync(s => s.Time.Date == today);
            var result = mapper.Map<IEnumerable<SaleResultDto>>(sales);
            return result;
        }

        //public async Task<decimal> GetTodayTotalAmountAsync()
        //{
        //    var amounts = await unitOfWork.GetRepository<Sale>()
        //                        .SumAsync(s => s.Time.Date == DateTime.UtcNow.Date, s => s.Price * s.Quantity);
        //    return amounts;
        //}
        public async Task AddSaleAsync(AddSaleResultDto dto)
        {
            Sale sale = null;
            switch (dto.ProductType.ToLower())
            {
                case "cover":
                    var cover = await unitOfWork.GetRepository<Cover>().GetByIdAsync(dto.ProductId);
                    if (cover == null) throw new Exception("Cover not found");
                    if(cover.Quantity < dto.Quantity) throw new Exception($"Not enough stock for {cover.Name}");
                    cover.Quantity -= dto.Quantity;
                    sale = new Sale
                    {
                        Name = cover.Name,
                        Quantity = dto.Quantity,
                        Price = cover.Price,
                        Time = DateTime.UtcNow,
                        Type = "cover",
                        ProductId = cover.Id
                    };
                    unitOfWork.GetRepository<Cover>().Update(cover);
                    break;
                case "screen":
                    var screen = await unitOfWork.GetRepository<Screen>().GetByIdAsync(dto.ProductId);
                    if (screen == null) throw new Exception("Screen not found");
                    if (screen.Quantity < dto.Quantity) throw new Exception($"Not enough stock for {screen.Name}");
                    screen.Quantity -= dto.Quantity;
                    sale = new Sale
                    {
                        Name = screen.Name,
                        Quantity = dto.Quantity,
                        Price = screen.Price,
                        Time = DateTime.UtcNow,
                        Type = "screen",
                        ProductId = screen.Id
                    };
                    unitOfWork.GetRepository<Screen>().Update(screen);
                    break;
                case "charger":
                    var charger = await unitOfWork.GetRepository<Charger>().GetByIdAsync(dto.ProductId);
                    if (charger == null) throw new Exception("Charger not found");
                    if (charger.Quantity < dto.Quantity) throw new Exception($"Not enough stock for {charger.Name}");
                    charger.Quantity -= dto.Quantity;
                    sale = new Sale
                    {
                        Name = charger.Name,
                        Quantity = dto.Quantity,
                        Price = charger.Price,
                        Time = DateTime.UtcNow,
                        Type = "charger",
                        ProductId = charger.Id
                    };
                    unitOfWork.GetRepository<Charger>().Update(charger);
                    break;
                case "headphone":
                    var headphone = await unitOfWork.GetRepository<HeadPhone>().GetByIdAsync(dto.ProductId);
                    if (headphone == null) throw new Exception("Headphone not found");
                    if (headphone.Quantity < dto.Quantity) throw new Exception($"Not enough stock for {headphone.Name}");
                    headphone.Quantity -= dto.Quantity;
                    sale = new Sale
                    {
                        Name = headphone.Name,
                        Quantity = dto.Quantity,
                        Price = headphone.Price,
                        Time = DateTime.UtcNow,
                        Type = "headphone",
                        ProductId = headphone.Id
                    };
                    unitOfWork.GetRepository<HeadPhone>().Update(headphone);
                    break;
                case "watch":
                    var watch = await unitOfWork.GetRepository<Watch>().GetByIdAsync(dto.ProductId);
                    if (watch == null) throw new Exception("Watch not found");
                    if (watch.Quantity < dto.Quantity) throw new Exception($"Not enough stock for {watch.Name}");
                    watch.Quantity -= dto.Quantity;
                    sale = new Sale
                    {
                        Name = watch.Name,
                        Quantity = dto.Quantity,
                        Price = watch.Price,
                        Time = DateTime.UtcNow,
                        Type = "watch",
                        ProductId = watch.Id
                    };
                    unitOfWork.GetRepository<Watch>().Update(watch);
                    break;
                case "cable":
                    var cable = await unitOfWork.GetRepository<Cable>().GetByIdAsync(dto.ProductId);
                    if (cable == null) throw new Exception("Cable not found");
                    if (cable.Quantity < dto.Quantity) throw new Exception($"Not enough stock for {cable.Name}");
                    cable.Quantity -= dto.Quantity;
                    sale = new Sale
                    {
                        Name = cable.Name,
                        Quantity = dto.Quantity,
                        Price = cable.Price,
                        Time = DateTime.UtcNow,
                        Type = "cable",
                        ProductId = cable.Id
                    };
                    unitOfWork.GetRepository<Cable>().Update(cable);
                    break;
                case "others":
                    var Other = await unitOfWork.GetRepository<Others>().GetByIdAsync(dto.ProductId);
                    if (Other == null) throw new Exception("Other product not found");
                    if (Other.Quantity < dto.Quantity) throw new Exception($"Not enough stock for {Other.Name}");
                    Other.Quantity -= dto.Quantity;
                    sale = new Sale
                    {
                        Name = Other.Name,
                        Quantity = dto.Quantity,
                        Price = Other.Price,
                        Time = DateTime.UtcNow,
                        Type = "others",
                        ProductId = Other.Id
                    };
                    unitOfWork.GetRepository<Others>().Update(Other);
                    break;
                default:
                    throw new Exception("Invalid product type");
            }

            sale.CalculateTotal();
            unitOfWork.GetRepository<Sale>().AddAsync(sale);
            await unitOfWork.SaveChangesAsync();
            
        }

        public async Task DeleteSaleAsync(int id)
        {
            var sale =await unitOfWork.GetRepository<Sale>().GetAsync(s => s.Id == id);
            if (sale == null) throw new SaleNotFoundException("Sale Not Found");
            switch (sale.Type.ToLower())
            {
                case "cover":
                    var cover = await unitOfWork.GetRepository<Cover>().GetByIdAsync(sale.ProductId);
                    if (cover != null)
                    {
                        cover.Quantity += sale.Quantity;
                        unitOfWork.GetRepository<Cover>().Update(cover);
                    }
                    break;

                case "screen":
                    var screen = await unitOfWork.GetRepository<Screen>().GetByIdAsync(sale.ProductId);
                    if (screen != null)
                    {
                        screen.Quantity += sale.Quantity;
                        unitOfWork.GetRepository<Screen>().Update(screen);
                    }
                    break;

                case "charger":
                    var charger = await unitOfWork.GetRepository<Charger>().GetByIdAsync(sale.ProductId);
                    if (charger != null)
                    {
                        charger.Quantity += sale.Quantity;
                        unitOfWork.GetRepository<Charger>().Update(charger);
                    }
                    break;

                case "headphone":
                    var headphone = await unitOfWork.GetRepository<HeadPhone>().GetByIdAsync(sale.ProductId);
                    if (headphone != null)
                    {
                        headphone.Quantity += sale.Quantity;
                        unitOfWork.GetRepository<HeadPhone>().Update(headphone);
                    }
                    break;

                case "watch":
                    var watch = await unitOfWork.GetRepository<Watch>().GetByIdAsync(sale.ProductId);
                    if (watch != null)
                    {
                        watch.Quantity += sale.Quantity;
                        unitOfWork.GetRepository<Watch>().Update(watch);
                    }
                    break;

                case "cable":
                    var cable = await unitOfWork.GetRepository<Cable>().GetByIdAsync(sale.ProductId);
                    if (cable != null)
                    {
                        cable.Quantity += sale.Quantity;
                        unitOfWork.GetRepository<Cable>().Update(cable);
                    }
                    break;

                case "others":
                    var other = await unitOfWork.GetRepository<Others>().GetByIdAsync(sale.ProductId);
                    if (other != null)
                    {
                        other.Quantity += sale.Quantity;
                        unitOfWork.GetRepository<Others>().Update(other);
                    }
                    break;

                default:
                    throw new Exception("Invalid product type in sale.");
            }
            unitOfWork.GetRepository<Sale>().Delete(sale);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
