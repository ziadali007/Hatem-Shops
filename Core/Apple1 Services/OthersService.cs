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
    public class OthersService(IMapper mapper,IUnitOfWork unitOfWork) : IOthersService
    {
        public async Task<IEnumerable<OthersResultDto>> GetAllOthersAsync()
        {
            var others =await unitOfWork.GetRepository<Others>().GetAllAsync();
            var result = mapper.Map<IEnumerable<OthersResultDto>>(others);
            return result;
        }

        public async Task<OthersResultDto> GetOtherByNameAsync(string name)
        {
            var other =await unitOfWork.GetRepository<Others>()
                                .GetAsync(c => c.Name == name);
            if (other == null) throw new OthersNotFoundException("Other Not Found");
            var result = mapper.Map<OthersResultDto>(other);
            return result;
        }
        public async Task CreateOtherAsync(AddOthersResultDto otherDto)
        {
           var other = mapper.Map<Others>(otherDto);
            await unitOfWork.GetRepository<Others>().AddAsync(other);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateOtherAsync(AddOthersResultDto otherDto)
        {
            var other = mapper.Map<Others>(otherDto);
            unitOfWork.GetRepository<Others>().Update(other);
            await unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteOtherAsync(int id)
        {
            var other =await unitOfWork.GetRepository<Others>().GetAsync(c => c.Id == id);
            if (other == null) throw new OthersNotFoundException("Other Not Found");
            unitOfWork.GetRepository<Others>().Delete(other);
            await unitOfWork.SaveChangesAsync();
        }

    }
}
