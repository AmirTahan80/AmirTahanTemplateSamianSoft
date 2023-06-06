using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Nest;
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
        private readonly ElasticClient _client;
        public ElasticsearchSetup()
        {
            //var settings = new ElasticsearchClientSettings(new Uri("http://10.0.2.168:9200"))
            //    .DefaultIndex("ObjectTemplate")
            //.Authentication(new BasicAuthentication("elastic", "tQ8uI8uACpf8iItgaaKg"));
            //settings.EnableApiVersioningHeader();
            //_client = new ElasticsearchClient(settings);
            var settings = new ConnectionSettings(new Uri("http://10.0.2.168:9200"))
                .BasicAuthentication("elastic", "tQ8uI8uACpf8iItgaaKg")
                .DefaultIndex("Object")
                .EnableApiVersioningHeader();
            _client = new ElasticClient(settings);
        }
        #endregion

        public async Task<ResultDto> IndexObject(string objectTemplate)
        {
            try
            {
                var res =await _client.IndexDocumentAsync(objectTemplate);
                var t = res.DebugInformation;
                if(res.IsValid)
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
