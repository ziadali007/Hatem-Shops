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
    public class OthersService(IMapper mapper,IUnitOfWork unitOfWork) : IOthersService
    {
        public async Task<IEnumerable<OthersResultDto>> GetAllOthersAsync()
        {
            var others =await unitOfWork.GetRepository<Others>().GetAllAsync();
            var result = mapper.Map<IEnumerable<OthersResultDto>>(others);
            return result;
        }

        public async Task<IEnumerable<OthersResultDto>> GetOtherByNameAsync(string name)
        {
            name = name.Replace(" ", " ").ToLower();
            var other = await unitOfWork.GetRepository<Others>()
                                .GetAsyncCollection(c => c.Name.Replace(" ", "")
                                                                    .ToLower().ToLower().Contains(name));
            if (other == null) throw new OthersNotFoundException("Other Not Found");
            var result = mapper.Map<IEnumerable<OthersResultDto>>(other);
            return result;
        }
        public async Task CreateOtherAsync(AddOthersResultDto otherDto)
        {
           var other = mapper.Map<Others>(otherDto);
            await unitOfWork.GetRepository<Others>().AddAsync(other);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateOtherAsync(OthersResultDto otherDto)
        {
            var existingOther = await unitOfWork.GetRepository<Others>().GetByIdAsync(otherDto.OtherId);
            if (existingOther == null) throw new OthersNotFoundException("Other Not Found");
            var other = mapper.Map(otherDto,existingOther);
            unitOfWork.GetRepository<Others>().Update(other);
            var result= await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new Exception("Update Failed");

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
