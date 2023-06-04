namespace SamianSoft.Infrastructure.Elasticsearch
{
    public interface ISerilogLogginSettup
    {
        Task SaveToElastic(string obj);
    }
}
