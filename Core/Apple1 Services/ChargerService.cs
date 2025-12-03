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
    public class ChargerService(IMapper mapper,IUnitOfWork unitOfWork ) : IChargerService
    {
        public async Task<IEnumerable<ChargerResultDto>> GetAllChargersAsync()
        {
            var Chargers = await unitOfWork.GetRepository<Charger>().GetAllAsync();
            var result = mapper.Map<IEnumerable<ChargerResultDto>>(Chargers);
            return result;
        }

        public async Task<IEnumerable<ChargerResultDto>> GetChargerByNameAsync(string name)
        {
            name = name.Replace(" ", " ").ToLower();
            var charger = await unitOfWork.GetRepository<Charger>()
                                .GetAsyncCollection(c => c.Name.Replace(" ", "")
                                                                    .ToLower().ToLower().Contains(name));
            if (charger == null) throw new ChargerNotFoundException("Charger Not Found");
            var result = mapper.Map<IEnumerable<ChargerResultDto>>(charger);
            return result;
        }
        public async Task CreateChargerAsync(AddChargerResultDto chargerDto)
        {
            var charger = mapper.Map<Charger>(chargerDto);
            await unitOfWork.GetRepository<Charger>().AddAsync(charger);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateChargerAsync(ChargerResultDto chargerDto)
        {
            var existingCharger =await unitOfWork.GetRepository<Charger>().GetByIdAsync(chargerDto.ChargerId);
            if (existingCharger == null) throw new ChargerNotFoundException("Charger Not Found");
            var charger = mapper.Map(chargerDto,existingCharger);
            unitOfWork.GetRepository<Charger>().Update(charger);
            var result=await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new Exception("Update Failed");

        }
        public async Task DeleteChargerAsync(int id)
        {
            var charger=await unitOfWork.GetRepository<Charger>().GetAsync(c => c.Id == id);
            if (charger == null) throw new ChargerNotFoundException("Charger Not Found");
            unitOfWork.GetRepository<Charger>().Delete(charger);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
