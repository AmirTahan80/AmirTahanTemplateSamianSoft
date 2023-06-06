using Nest;
using SamianSoft.Application.DTOs;
using SamianSoft.Application.Services.ObjectTemplate;

namespace SamianSoft.Infrastructure.Elasticsearch
{
    public interface IElasticsearchSetup
    {
        Task<ResultDto> IndexObject(ObjectTemplateDto objectTemplate);
    }
    public class ElasticsearchSetup : IElasticsearchSetup
    {
        #region Properties and contructors
        private readonly ElasticClient _client;
        public ElasticsearchSetup()
        {
            var settings = new ConnectionSettings(new Uri("https://10.0.2.168:9200"))
                .DefaultIndex("objecttemplatedto")
                .CertificateFingerprint("C4:A1:D2:F3:D0:49:F3:B0:EF:A6:58:4F:D4:50:19:EC:DF:04:C3:DA:81:8C:7C:16:12:BA:D9:3E:4F:51:4B:3C")
                .BasicAuthentication("elastic", "tQ8uI8uACpf8iItgaaKg")
                .EnableApiVersioningHeader();
            _client = new ElasticClient(settings);
        }
        #endregion

        public async Task<ResultDto> IndexObject(ObjectTemplateDto objectTemplate)
        {
            try
            {
                var res = await _client.IndexDocumentAsync<ObjectTemplateDto>(objectTemplate);
                var t = res.DebugInformation;
                if (res.IsValid)
                {
                    return new()
                    {
                        IsSuccess = true,
                        Data = objectTemplate,
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Message = res.Index + " => Save!"
                    };
                }
                else
                    return new() { IsSuccess = false, Data = objectTemplate, StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "" };
            }
            catch (Exception ex)
            {
                return new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.InternalServerError };
            }
        }

 //       { "CreateUserId": 0,
 //"RequestURL": "/v2/account/erpweb/profile/image/?userId=1105&companyId=1&dummyCounter=0",
 //"SessionId": "5ae96609-202d-41eb-aaa6-4724ba3e71c5",
 //"ClientIP": "127.0.0.1",
 //"RequestId": "0HMMBKPFPNMU6:00000002",
 //"HttpMethod": "POST",
 //"Host": "http://localhost:8086",
 //"Agent": "PostmanRuntime/7.29.2",
 //"XClientVersion": "4.18.1Rc",
 //"XClientName": "SamianSoft",
 //"ApiVersion": "2.18.0-b.2" }
}
}
