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
    public class HeadPhoneService(IMapper mapper,IUnitOfWork unitOfWork) : IHeadPhonesServices
    {
        public async Task<IEnumerable<HeadPhoneResultDto>> GetAllHeadPhonesAsync()
        {
            var headPhones =await unitOfWork.GetRepository<HeadPhone>().GetAllAsync();
            var result = mapper.Map<IEnumerable<HeadPhoneResultDto>>(headPhones);
            return result;
        }

        public async Task<IEnumerable<HeadPhoneResultDto>> GetHeadPhonesByNameAsync(string name)
        {
            name = name.Replace(" ", " ").ToLower();
            var headPhone = await unitOfWork.GetRepository<HeadPhone>()
                                .GetAsyncCollection(c => c.Name.Replace(" ", "")
                                                                    .ToLower().ToLower().Contains(name));
            if (headPhone == null) throw new HeadPhoneNotFoundException("HeadPhone Not Found");
            var result = mapper.Map<IEnumerable<HeadPhoneResultDto>>(headPhone);
            return result;
        }

        public async Task CreateHeadPhonesAsync(AddHeadPhoneResultDto headPhonesDto)
        {
            var headPhone = mapper.Map<HeadPhone>(headPhonesDto);
            await unitOfWork.GetRepository<HeadPhone>().AddAsync(headPhone);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task UpdateHeadPhonesAsync(HeadPhoneResultDto headPhonesDto)
        {
            var existingHeadPhone = await unitOfWork.GetRepository<HeadPhone>().GetByIdAsync(headPhonesDto.HeadPhoneId);
            if (existingHeadPhone == null) throw new HeadPhoneNotFoundException("HeadPhone Not Found");
            var headPhone = mapper.Map(headPhonesDto,existingHeadPhone);
            unitOfWork.GetRepository<HeadPhone>().Update(headPhone);
            var result=await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new Exception("Update Failed");

        }
        public async Task DeleteHeadPhonesAsync(int id)
        {
            var headPhone =await unitOfWork.GetRepository<HeadPhone>().GetAsync(c => c.Id == id);
            if (headPhone == null) throw new HeadPhoneNotFoundException("HeadPhone Not Found");
            unitOfWork.GetRepository<HeadPhone>().Delete(headPhone);
            await unitOfWork.SaveChangesAsync();
        }

    }
}
