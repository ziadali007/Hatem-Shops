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
    public class HeadPhoneService(IMapper mapper,IUnitOfWork unitOfWork) : IHeadPhonesServices
    {
        public async Task<IEnumerable<HeadPhoneResultDto>> GetAllHeadPhonesAsync()
        {
            var headPhones =await unitOfWork.GetRepository<HeadPhone>().GetAllAsync();
            var result = mapper.Map<IEnumerable<HeadPhoneResultDto>>(headPhones);
            return result;
        }

        public async Task<HeadPhoneResultDto> GetHeadPhonesByNameAsync(string name)
        {
            var headPhone =await unitOfWork.GetRepository<HeadPhone>()
                                .GetAsync(c => c.Name == name);
            if (headPhone == null) throw new HeadPhoneNotFoundException("HeadPhone Not Found");
            var result = mapper.Map<HeadPhoneResultDto>(headPhone);
            return result;
        }

        public async Task CreateHeadPhonesAsync(AddHeadPhoneResultDto headPhonesDto)
        {
            var headPhone = mapper.Map<HeadPhone>(headPhonesDto);
            await unitOfWork.GetRepository<HeadPhone>().AddAsync(headPhone);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task UpdateHeadPhonesAsync(AddHeadPhoneResultDto headPhonesDto)
        {
            var headPhone = mapper.Map<HeadPhone>(headPhonesDto);
            unitOfWork.GetRepository<HeadPhone>().Update(headPhone);
            await unitOfWork.SaveChangesAsync();
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
