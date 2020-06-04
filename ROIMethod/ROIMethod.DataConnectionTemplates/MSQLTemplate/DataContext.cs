using ROIMethod.DataInfrastructure.DataUtils.Repositories;
using ROIMethod.DataInfrastructure.DataUtils.Repositories._Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ROIMethod.DataConnectionTemplates.MSQLTemplate
{
    public class DataContext: IAppDataConnection
    {
        public AppContext AppContext { get; private set; }

        public DataContext(string connection)
        {
            AppContext = new AppContext(connection);
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
