using ROIMethod.DataInfrastructure.DataUtils.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ROIMethod.DataConnectionTemplates.PostgreSQLTemplate
{
    public class DataContext : IAppContext
    {
        public AppContext AppContext { get; private set; }

        public DataContext()
        {
            AppContext = new AppContext("Data Source=..\\..\\..\\db.psql");
        }

        public T GetRepository<T>() where T : IRepository
        {
            foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
            {
                if (typeof(T).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                {
                    T repository = (T)Activator.CreateInstance(type);

                    repository.SetDataConnectionContext(AppContext);
                    return repository;
                }
            }

            return default(T);
        }

        public void Save()
        {
            this.AppContext.SaveChanges();
        }
    }
}
