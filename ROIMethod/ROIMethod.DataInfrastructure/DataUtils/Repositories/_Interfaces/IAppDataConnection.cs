using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.DataInfrastructure.DataUtils.Repositories._Interfaces
{
    // connection with another DB
    public interface IAppDataConnection
    {
        T GetRepository<T>() where T : IRepository;
        void Save();
    }
}
