using SamianSoft.Application.Services.ObjectTemplate.Commands;
using SamianSoft.Persistence.Data;

namespace AmirTahanTemplateSamianSoft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllers();
            #region AddDbContext
            builder.Services.AddDbContext<SFDbContext>();
            #endregion
            #region Injections
            builder.Services.AddScoped<IAddObjectTemplateRepository, AddObjectTemplateRepository>();
            #endregion
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
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