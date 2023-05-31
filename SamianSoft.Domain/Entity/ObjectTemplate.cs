namespace SamianSoft.Domain.Entity
{
    public class ObjectTemplate:Field
    {
        public int CreateUserId { get; set; }
        public string RequestUrl { get; set; }
        public string SessionId { get; set; }
        public string ClientIP { get; set; }
        public string RequestId { get; set; }
        public string HttpMethod { get; set; }
        public string Host { get; set; }
        public string Agent { get; set; }
        public string XClientVersion { get; set; }
        public string XClientName { get; set; }
        public string ApiVersion { get; set; }
    }
}
