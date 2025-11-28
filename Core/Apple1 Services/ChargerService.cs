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

        public async Task<ChargerResultDto> GetChargerByNameAsync(string name)
        {
            var charger =await unitOfWork.GetRepository<Charger>()
                                .GetAsync(c => c.Name == name);
            if (charger == null) throw new ChargerNotFoundException("Charger Not Found");
            var result = mapper.Map<ChargerResultDto>(charger);
            return result;
        }
        public async Task CreateChargerAsync(AddChargerResultDto chargerDto)
        {
            var charger = mapper.Map<Charger>(chargerDto);
            await unitOfWork.GetRepository<Charger>().AddAsync(charger);
            await unitOfWork.SaveChangesAsync();
        }

        public Task UpdateChargerAsync(AddChargerResultDto chargerDto)
        {
            var charger = mapper.Map<Charger>(chargerDto);
            unitOfWork.GetRepository<Charger>().Update(charger);
            return unitOfWork.SaveChangesAsync();
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
