using Ninject.Modules;
using ROIMethod.DataConnectionTemplates.MSQLTemplate;
using ROIMethod.DataInfrastructure.DataUtils.Repositories._Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.WebAPI.Core.CaseServices
{
    public class NModule : NinjectModule
    {
        private string connectionString;
        public NModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IAppDataConnection>().To<DataContext>().WithConstructorArgument(connectionString);
        }
    }
}
