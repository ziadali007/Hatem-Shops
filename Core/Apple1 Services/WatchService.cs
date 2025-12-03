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
    public class WatchService(IMapper mapper, IUnitOfWork unitOfWork) : IWatchService
    {
        public async Task<IEnumerable<WatchResultDto>> GetAllWatches()
        {
            var watches = await unitOfWork.GetRepository<Watch>().GetAllAsync();
            var result = mapper.Map<IEnumerable<WatchResultDto>>(watches);
            return result;
        }

        public async Task<IEnumerable<WatchResultDto>> GetWatchByNameAsync(string name)
        {
            name = name.Replace(" ", " ").ToLower();
            var watches = await unitOfWork.GetRepository<Watch>()
                                .GetAsyncCollection(c => c.Name.Replace(" ", "")
                                                                    .ToLower().ToLower().Contains(name));
            if (watches == null) throw new WatchesNotFoundException("There Is No Watches");
            var result = mapper.Map<IEnumerable<WatchResultDto>> (watches);
            return result;
        }
        public async Task CreateWatchAsync(AddWatchResultDto watchDto)
        {
            var watch= mapper.Map<Watch>(watchDto);
            await unitOfWork.GetRepository<Watch>().AddAsync(watch);
            var result= await unitOfWork.SaveChangesAsync();
            if(result == 0) throw new WatchesNotFoundException("There Is No Watches");

        }
        public async Task UpdateWatchAsync(WatchResultDto watchDto)
        {
            var watch = await unitOfWork.GetRepository<Watch>().GetByIdAsync(watchDto.WatchId);
            if (watch == null) throw new WatchesNotFoundException("Watch Not Found");
            var result=mapper.Map(watchDto,watch);
            unitOfWork.GetRepository<Watch>().Update(result);
            var res = await unitOfWork.SaveChangesAsync();
            if (res == 0) throw new Exception("Update Failed");
        }
        public async Task DeleteWatchAsync(int id)
        {
            var watch =await unitOfWork.GetRepository<Watch>().GetByIdAsync(id);
            if (watch == null) throw new WatchesNotFoundException("Watch Not Found");
            unitOfWork.GetRepository<Watch>().Delete(watch);
            await unitOfWork.SaveChangesAsync();
        }

    }
}
