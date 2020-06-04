using ROIMethod.WebAPI.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.WebAPI.Core.CaseServices.Interface
{
    public interface IStatisticService
    {
        IEnumerable<StatisticDTO> getAllStatistic();
    }
}
