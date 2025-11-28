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
    public class CoverService(IMapper mapper,IUnitOfWork unitOfWork) : ICoverService
    {

        public async Task<IEnumerable<CoverResultDto>> GetAllCoversAsync()
        {
            var Covers= await unitOfWork.GetRepository<Cover>().GetAllAsync();
            var result = mapper.Map<IEnumerable<CoverResultDto>>(Covers);
            return result;
        }

        public async Task<CoverResultDto> GetCoverByNameAsync(string name)
        {
            var cover = await unitOfWork.GetRepository<Cover>()
                                .GetAsync(c => c.Name == name);

            if (cover == null) throw new CoverNotFoundException("Cover Not Found");

            var result = mapper.Map<CoverResultDto>(cover);

            return result;

        }

        public async Task CreateCoverAsync(AddCoverResultDto coverDto)
        {
            var cover = mapper.Map<Cover>(coverDto);
            await unitOfWork.GetRepository<Cover>().AddAsync(cover);
            await unitOfWork.SaveChangesAsync();

        }
        public async Task UpdateCoverAsync(AddCoverResultDto coverDto)
        {
            var cover = mapper.Map<Cover>(coverDto);
            unitOfWork.GetRepository<Cover>().Update(cover);
            await unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteCoverAsync(int id)
        {
            var cover= await unitOfWork.GetRepository<Cover>().GetAsync(c => c.Id == id);
            if (cover == null) throw new CoverNotFoundException("Cover Not Found");
            unitOfWork.GetRepository<Cover>().Delete(cover);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
