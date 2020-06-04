using AutoMapper;
using ROIMethod.DataInfrastructure.DataUtils.Entities;
using ROIMethod.DataInfrastructure.DataUtils.Repositories;
using ROIMethod.DataInfrastructure.DataUtils.Repositories._Interfaces;
using ROIMethod.WebAPI.Core.CaseServices.Interface;
using ROIMethod.WebAPI.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.WebAPI.Core.CaseServices
{
    public class StatisticService : IStatisticService
    {
        private IAppDataConnection connection;

        public StatisticService(IAppDataConnection connection)
        {
            this.connection = connection;
        }

        #region Cases
        public IEnumerable<StatisticDTO> getAllStatistic()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Statistic, StatisticDTO>()).CreateMapper();
            var data = this.connection.GetRepository<IStatisticRepository>().All();
            return mapper.Map<IEnumerable<Statistic>, List<StatisticDTO>>(data);
        }
        #endregion
    }
}
