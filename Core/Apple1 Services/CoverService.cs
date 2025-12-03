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

        public async Task<IEnumerable<CoverResultDto>> GetCoverByNameAsync(string name)
        {
            name=name.Replace(" ", " ").ToLower();
            var cover = await unitOfWork.GetRepository<Cover>()
                                .GetAsyncCollection(c => c.Name.Replace(" ", "")
                                                                    .ToLower().ToLower().Contains(name));

            if (cover == null) throw new CoverNotFoundException("Cover Not Found");

            var result = mapper.Map<IEnumerable<CoverResultDto>>(cover);

            return result;

        }

        public async Task CreateCoverAsync(AddCoverResultDto coverDto)
        {
            var cover = mapper.Map<Cover>(coverDto);
            await unitOfWork.GetRepository<Cover>().AddAsync(cover);
            await unitOfWork.SaveChangesAsync();

        }
        public async Task UpdateCoverAsync(CoverResultDto coverDto)
        {
            var existingCover = await unitOfWork.GetRepository<Cover>()
                                        .GetByIdAsync(coverDto.CoverId);
            if (existingCover == null) throw new CoverNotFoundException("Cover Not Found");
            var cover = mapper.Map(coverDto,existingCover);
            unitOfWork.GetRepository<Cover>().Update(cover);
            var result= await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new Exception("Update Failed");

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
