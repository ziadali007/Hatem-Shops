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
        Task<IEnumerable<HeadPhoneResultDto>> GetHeadPhonesByNameAsync(string name);
        Task CreateHeadPhonesAsync(AddHeadPhoneResultDto headPhonesDto);
        Task UpdateHeadPhonesAsync( HeadPhoneResultDto headPhonesDto);
        Task DeleteHeadPhonesAsync(int id);
    }
}
