using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsha3er_Shared;
namespace Elsha3er_Services.Abstractions
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
