using ROIMethod.DataInfrastructure.DataUtils.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.DataInfrastructure.DataUtils.Repositories
{
        public interface IStatisticRepository : IRepository
        {
            IEnumerable<Statistic> All();
        }
}
