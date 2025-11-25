using Apple1_Domain.Contracts;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
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
