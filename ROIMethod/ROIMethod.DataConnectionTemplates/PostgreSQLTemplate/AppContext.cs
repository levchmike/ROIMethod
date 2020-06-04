using Microsoft.EntityFrameworkCore;
using ROIMethod.DataInfrastructure.DataUtils.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.DataConnectionTemplates.PostgreSQLTemplate
{
    public class AppContext: DbContext, IAppContext
    {
        private string connectionString;

        public AppContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
