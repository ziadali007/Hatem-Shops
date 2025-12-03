using Elsha3er_Domain.Contracts;
using Elsha3er_Services.Abstractions;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Presistence.Repositories
{
    public class DailySalesQuartzJob : IJob
    {
        private readonly IArchiveDailySalesService _archive;
        public DailySalesQuartzJob(IArchiveDailySalesService archive)
        {
            _archive = archive;
        }
        public async Task Execute(IJobExecutionContext context)
        {
           await _archive.ArchiveAsync();
        }
    }
}
