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

        public async Task<IEnumerable<ScreenResultDto>> GetScreenByNameAsync(string name)
        {
            name = name.Replace(" ", " ").ToLower();
            var screen = await unitOfWork.GetRepository<Screen>()
                                .GetAsyncCollection(c => c.Name.Replace(" ", "")
                                                                    .ToLower().Contains(name));
            if (screen == null) throw new ScreenNotFoundException("Screen Not Found");
            var result = mapper.Map<IEnumerable<ScreenResultDto>>(screen);
            return result;
        }

        public async Task CreateScreenAsync(AddScreenResultDto screenDto)
        {
            var screen = mapper.Map<Screen>(screenDto);
            await unitOfWork.GetRepository<Screen>().AddAsync(screen);
            await unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateScreenAsync(ScreenResultDto screenDto)
        {
            var existingScreen =await unitOfWork.GetRepository<Screen>().GetByIdAsync(screenDto.ScreenId);
            if (existingScreen == null) throw new ScreenNotFoundException("Screen Not Found");
            var screen = mapper.Map(screenDto, existingScreen);
            unitOfWork.GetRepository<Screen>().Update(screen);
            var result=await unitOfWork.SaveChangesAsync();
            if(result == 0) throw new Exception("Update Failed");
        }
        public async Task DeleteScreenAsync(int id)
        {
            var screen =await unitOfWork.GetRepository<Screen>().GetAsync(c => c.Id == id);
            if (screen == null) throw new ScreenNotFoundException("Screen Not Found");
            unitOfWork.GetRepository<Screen>().Delete(screen);
            await unitOfWork.SaveChangesAsync();
        }

    }
}
