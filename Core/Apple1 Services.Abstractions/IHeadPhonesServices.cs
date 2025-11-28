using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
namespace Apple1_Services.Abstractions
{
    public interface IHeadPhonesServices
    {
        Task<IEnumerable<HeadPhoneResultDto>> GetAllHeadPhonesAsync();
        Task<HeadPhoneResultDto> GetHeadPhonesByNameAsync(string name);
        Task CreateHeadPhonesAsync(AddHeadPhoneResultDto headPhonesDto);
        Task UpdateHeadPhonesAsync(AddHeadPhoneResultDto headPhonesDto);
        Task DeleteHeadPhonesAsync(int id);
    }
}
