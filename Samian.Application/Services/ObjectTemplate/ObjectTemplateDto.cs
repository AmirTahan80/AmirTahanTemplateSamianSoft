namespace SamianSoft.Application.Services.ObjectTemplate
{
    public record class ObjectTemplateDto(int CreateUserId,string RequestUrl, string SessionId, string ClientIP,
        string RequestId, string HttpMethod, string Host, string Agent, string XClientVersion,
        string XClientName, string ApiVersion);
}
