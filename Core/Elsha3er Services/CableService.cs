using Elsha3er_Domain.Contracts;
using Elsha3er_Domain.Exceptions;
using Elsha3er_Domain.Models;
using AutoMapper;
using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsha3er_Services.Abstractions;

namespace Elsha3er_Services
{
    public class CableService(IMapper mapper,IUnitOfWork unitOfWork) : ICableServices
    {
        public async Task<IEnumerable<CableResultDto>> GetAllCablesAsync()
        {
            var cables = await unitOfWork.GetRepository<Cable>().GetAllAsync();
            var result = mapper.Map<IEnumerable<CableResultDto>>(cables);
            return result;
        }

        public async Task<IEnumerable<CableResultDto>> GetCableByNameAsync(string name)
        {
            name = name.Replace(" ", " ").ToLower();
            var cable = await unitOfWork.GetRepository<Cable>()
                                .GetAsyncCollection(c => c.Name.Replace(" ", "")
                                                                    .ToLower().ToLower().Contains(name));
            if (cable == null) throw new CableNotFoundException("Cable Not Found");
            var result = mapper.Map<IEnumerable<CableResultDto>>(cable);
            return result;
        }

        public async Task CreateCableAsync(AddCableResultDto cableDto)
        {
           var cable = mapper.Map<Cable>(cableDto);
           await unitOfWork.GetRepository<Cable>().AddAsync(cable);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCableAsync(CableResultDto cableDto)
        {
            var existingCable = await unitOfWork.GetRepository<Cable>().GetByIdAsync(cableDto.CableId);
            if (existingCable == null) throw new CableNotFoundException("Cable Not Found");
            var cable = mapper.Map(cableDto,existingCable);
            unitOfWork.GetRepository<Cable>().Update(cable);
            var result= await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new Exception("Update Failed");

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
