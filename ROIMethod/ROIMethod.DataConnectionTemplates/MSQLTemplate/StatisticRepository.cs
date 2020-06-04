using Microsoft.EntityFrameworkCore;
using ROIMethod.DataInfrastructure.DataUtils.Entities;
using ROIMethod.DataInfrastructure.DataUtils.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROIMethod.DataConnectionTemplates.MSQLTemplate
{
    public class StatisticRepository: IStatisticRepository
    {
        private AppContext appContext;
        private DbSet<Statistic> dbSet;

        public void SetDataConnectionContext(IAppContext appContext)
        {
            this.appContext = appContext as AppContext;
            this.dbSet = this.appContext.Set<Statistic>();
        }

        public IEnumerable<Statistic> All()
        {
            var data = this.dbSet.OrderBy(i => i.DescriptionInfo);
            return data;
        }
    }
}
