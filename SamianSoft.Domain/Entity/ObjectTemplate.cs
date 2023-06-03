using System.ComponentModel.DataAnnotations;

namespace SamianSoft.Domain.Entity
{
    public class ObjectTemplate:Field
    {
        [Required]
        public int CreateUserId { get; set; }
        [Required]
        public string RequestUrl { get; set; }                          
        [Required]
        public string SessionId { get; set; }                           
        [Required]
        public string ClientIP { get; set; }                            
        [Required]
        public string RequestId { get; set; }                           
        [Required]
        public string HttpMethod { get; set; }                          
        [Required]
        public string Host { get; set; }                                
        [Required]
        public string Agent { get; set; }                               
        [Required]
        public string XClientVersion { get; set; }                      
        [Required]
        public string XClientName { get; set; }                         
        [Required]
        public string ApiVersion { get; set; }
    }
}
