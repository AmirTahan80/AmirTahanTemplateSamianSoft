using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using SamianSoft.Application.DTOs;

namespace SamianSoft.Infrastructure.Elasticsearch
{
    public interface IElasticsearchSetup
    {
        Task<ResultDto> IndexObject(string objectTemplate);
    }
    public class ElasticsearchSetup: IElasticsearchSetup
    {
        #region Properties and contructors
        private readonly ElasticsearchClient _client;
        public ElasticsearchSetup()
        {
            var settings = new ElasticsearchClientSettings(new Uri("http://10.0.2.168:9200/"))
                .DefaultIndex("ObjectTemplate")
            .Authentication(new BasicAuthentication("elastic", "Ar7uqhTCc+Vm9zT=Tjhg"));
            _client = new ElasticsearchClient(settings);
        }
        #endregion

        public async Task<ResultDto> IndexObject(string objectTemplate)
        {
            try
            {
                var res =await _client.IndexAsync(objectTemplate);
                var t = res.DebugInformation;
                var b = res.IsValidResponse;
                var c = res.ApiCallDetails;
                var d = res.ElasticsearchServerError;
                if(res.IsSuccess())
                {
                    return new()
                    {
                        IsSuccess= true,
                        Data=objectTemplate,
                        StatusCode=System.Net.HttpStatusCode.OK,
                        Message=res.Index+ " => Save!"
                    };
                }
                else
                    return new() { IsSuccess= false, Data=objectTemplate,StatusCode=System.Net.HttpStatusCode.BadRequest,Message="" };
            }
            catch (Exception ex)
            {
                return new() { IsSuccess=false,StatusCode=System.Net.HttpStatusCode.InternalServerError};
            }
        }
    }
}
