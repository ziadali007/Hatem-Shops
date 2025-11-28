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
    public class CableService(IMapper mapper,IUnitOfWork unitOfWork) : ICableServices
    {
        public async Task<IEnumerable<CableResultDto>> GetAllCablesAsync()
        {
            var cables = await unitOfWork.GetRepository<Cable>().GetAllAsync();
            var result = mapper.Map<IEnumerable<CableResultDto>>(cables);
            return result;
        }

        public async Task<CableResultDto> GetCableByNameAsync(string name)
        {
            var cable = await unitOfWork.GetRepository<Cable>()
                                .GetAsync(c => c.Name == name);
            if (cable == null) throw new CableNotFoundException("Cable Not Found");
            var result = mapper.Map<CableResultDto>(cable);
            return result;
        }

        public async Task CreateCableAsync(AddCableResultDto cableDto)
        {
           var cable = mapper.Map<Cable>(cableDto);
           await unitOfWork.GetRepository<Cable>().AddAsync(cable);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCableAsync(AddCableResultDto cableDto)
        {
            var cable = mapper.Map<Cable>(cableDto);
            unitOfWork.GetRepository<Cable>().Update(cable);
            await unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteCableAsync(int id)
        {
            var cable =await unitOfWork.GetRepository<Cable>().GetAsync(c => c.Id == id);
            if (cable == null) throw new CableNotFoundException("Cable Not Found");
            unitOfWork.GetRepository<Cable>().Delete(cable);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
