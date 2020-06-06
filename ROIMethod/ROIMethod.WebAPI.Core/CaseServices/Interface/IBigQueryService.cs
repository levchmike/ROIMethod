using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using ROIMethod.WebAPI.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMethod.WebAPI.Core.CaseServices.Interface
{
    public interface IBigQueryService
    {
        List<TableRow> GetRows(string query);
        BigQueryClient GetConnectionClient();
    }

    public interface IBQStatisticService
    {
        IEnumerable<StatisticDTO> getAllStatistic();
    }
}
