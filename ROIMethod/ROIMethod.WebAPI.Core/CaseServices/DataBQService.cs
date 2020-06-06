using ROIMethod.WebAPI.Core.CaseServices.Interface;
using ROIMethod.WebAPI.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.WebAPI.Core.CaseServices
{
    public class DataBQService : IBQStatisticService
    {
        IBigQueryService _bq;
        public DataBQService(IBigQueryService bq)
        {
            _bq = bq;
        }

        public IEnumerable<StatisticDTO> getAllStatistic()
        {
            var query = "SELECT *FROM[Statistics.Statistics] LIMIT 25";

            var rows = _bq.GetRows(query);

            var result = new List<StatisticDTO>();

            rows.ForEach(row => result.Add(new StatisticDTO
            {
                Id = Convert.ToInt32(row.F[0].V),
                DescriptionInfo = row.F[1].V.ToString(),
                Clicks = Convert.ToInt32(row.F[2].V),
                Expend = Convert.ToInt32(row.F[3].V),
                Price = Convert.ToInt32(row.F[4].V),
                PriceClient = Convert.ToInt32(row.F[5].V),
                Conversion = Convert.ToInt32(row.F[6].V),
            }));

            return result;
        }
    }
}
