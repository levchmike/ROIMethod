using Google.Apis.Auth.OAuth2;
using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using ROIMethod.DataInfrastructure.DataUtils.Repositories._Interfaces;
using ROIMethod.WebAPI.Core.CaseServices.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ROIMethod.WebAPI.Core.CaseServices
{
    public class BigQueryService : IBigQueryService
    {
        const string PROJECT_ID = "roimethod";

        private IConfigBQConnection connection;

        public BigQueryService(IConfigBQConnection connection)
        {
            this.connection = connection;
        }

        public BigQueryClient GetConnectionClient()
        {
            var config = connection.GetConnection();

            GoogleCredential credential = null;
            using (var jsonStream = new FileStream(config, FileMode.Open, FileAccess.Read, FileShare.Read))
                credential = GoogleCredential.FromStream(jsonStream);

            return BigQueryClient.Create(PROJECT_ID, credential);
        }

        public List<TableRow> GetRows(string query)
        {
            var bqClient = GetConnectionClient();
            List<TableRow> response;
            QueryResponse queryResponse;
            SetInitQueryResponse(query, bqClient, out response, out queryResponse);

            if (queryResponse.JobComplete != false)
            {
                return queryResponse.Rows == null
                    ? new List<TableRow>()
                    : queryResponse.Rows.ToList();
            }

            var jobId = queryResponse.JobReference.JobId;
            var retry = true;
            var retryCounter = 0;

            while (retry && retryCounter < 50)
            {
                Thread.Sleep(1000);

                var queryResults = bqClient.Service.Jobs.GetQueryResults(PROJECT_ID, jobId).Execute();

                if (queryResults.JobComplete != true)
                {
                    retryCounter++;
                    continue;
                }

                if (queryResults.Rows != null)
                    response = queryResults.Rows.ToList();

                retry = false;
            }

            return response;
        }

        private static void SetInitQueryResponse(string query, BigQueryClient bqClient, out List<TableRow> response, out QueryResponse queryResponse)
        {
            response = new List<TableRow>();
            var jobResource = bqClient.Service.Jobs;
            var qr = new QueryRequest() { Query = query };
            queryResponse = jobResource.Query(qr, PROJECT_ID).Execute();
        }
    }
}
