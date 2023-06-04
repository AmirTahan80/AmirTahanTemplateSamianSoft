using Elasticsearch.Net;
using Nest;
using SamianSoft.Application.Services.ObjectTemplate.Commands;
using SamianSoft.Domain.DataInterface;
using SamianSoft.Infrastructure.Elasticsearch;
using SamianSoft.Persistence.Data;
using Serilog;
using static System.Reflection.Metadata.BlobBuilder;

namespace AmirTahanTemplateSamianSoft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            #region AddDbContext
            builder.Services.AddDbContext<ISF_DbContext,SFDbContext>();
            #endregion
            #region Injections
            builder.Services.AddScoped<IAddObjectTemplateRepository, AddObjectTemplateRepository>();
            //builder.Services.AddScoped<IElasticsearchSetup, ElasticsearchSetup>();
            builder.Services.AddScoped<ISerilogLogginSettup,SerilogLogging>();
            #endregion

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}