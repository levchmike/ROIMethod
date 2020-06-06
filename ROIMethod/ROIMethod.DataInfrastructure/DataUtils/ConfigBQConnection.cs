using ROIMethod.DataInfrastructure.DataUtils.Repositories._Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.DataInfrastructure.DataUtils
{
    public class ConfigBQConnection : IConfigBQConnection
    {
        private string conf;

        public ConfigBQConnection(string conf)
        {
            this.conf = conf;
        }

        public string GetConnection()
        {
            var confConnection = this.conf;
            return confConnection;
        }
    }
}
