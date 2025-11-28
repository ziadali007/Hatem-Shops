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
    public class ScreenService(IMapper mapper,IUnitOfWork unitOfWork) : IScreenService
    {
        public async Task<IEnumerable<ScreenResultDto>> GetAllScreensAsync()
        {
            var screens= await unitOfWork.GetRepository<Screen>().GetAllAsync();
            var result = mapper.Map<IEnumerable<ScreenResultDto>>(screens);
            return result;
        }

        public async Task<ScreenResultDto> GetScreenByNameAsync(string name)
        {
            var screen=await unitOfWork.GetRepository<Screen>()
                                .GetAsync(c => c.Name == name);
            if (screen == null) throw new ScreenNotFoundException("Screen Not Found");
            var result = mapper.Map<ScreenResultDto>(screen);
            return result;
        }

        public async Task CreateScreenAsync(AddScreenResultDto screenDto)
        {
            var screen = mapper.Map<Screen>(screenDto);
            await unitOfWork.GetRepository<Screen>().AddAsync(screen);
            await unitOfWork.SaveChangesAsync();
        }
        public Task UpdateScreenAsync(AddScreenResultDto screenDto)
        {
            var screen = mapper.Map<Screen>(screenDto);
            unitOfWork.GetRepository<Screen>().Update(screen);
            return unitOfWork.SaveChangesAsync();
        }
        public Task DeleteScreenAsync(int id)
        {
            var screen = unitOfWork.GetRepository<Screen>().GetAsync(c => c.Id == id);
            if (screen == null) throw new ScreenNotFoundException("Screen Not Found");
            unitOfWork.GetRepository<Screen>().Delete(screen.Result);
            return unitOfWork.SaveChangesAsync();
        }

    }
}
