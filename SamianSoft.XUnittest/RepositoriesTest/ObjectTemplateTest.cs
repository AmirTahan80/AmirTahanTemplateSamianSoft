using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using SamianSoft.Application.Services.ObjectTemplate;
using SamianSoft.Application.Services.ObjectTemplate.Commands;
using SamianSoft.Domain.DataInterface;
using SamianSoft.Domain.Entity;
using SamianSoft.Persistence.Data;
using SamianSoft.XUnittest.Extentions;
using Xunit;

namespace SamianSoft.XUnittest.RepositoriesTest
{
    public class ObjectTemplateTest
    {
        #region Constuctors and properies and variables
        private readonly DbContextOptions<SFDbContext> _options;
        private readonly Mock<IAddObjectTemplateRepository> _addObject = new();
        private readonly IMapper _mapper;
        private readonly Mock<ISF_DbContext> _db = new();

        public ObjectTemplateTest()
        {
            _options = CreateDataBaseInstanceHelper.CreateDbContextOption();
            var myProfile = new ObjectTemplateProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }
        #endregion

        #region Test Methods
        [Fact]
        public async void AddObjectTemplate_CreateNewTemplateInstanceAndSaveItToTheDataBase_ReturnAObjectFromDb()
        {
            // Arrange
            var template = new ObjectTemplateDto(1, "Test", "test", "test", "Test", "test", "test", "Test", "test", "test", "test");
            var services = new AddObjectTemplateRepository(new SFDbContext(_options), _mapper);

            // Act
            var res = await services.Execute(template);

            // Asserts
            Assert.True(res.IsSuccess);
        }

        #endregion
    }
}
