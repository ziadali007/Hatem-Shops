using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services.Abstractions
{
    public interface IDailySalesArchiveService
    {
        Task ArchiveDailySalesAsync(DateTime date);
    }
}
