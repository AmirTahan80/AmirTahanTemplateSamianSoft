﻿using Microsoft.EntityFrameworkCore;
using SamianSoft.Domain.Entity;
using SamianSoft.Persistence.Data;
using SamianSoft.XUnittest.Extentions;
using Xunit;

namespace SamianSoft.XUnittest.DataBaseTests
{
    public class DataTest
    {
        #region Consturcotr and properties and variables
        private readonly DbContextOptions<SFDbContext> _options;

        public DataTest()
        {
            _options = CreateDataBaseInstanceHelper.CreateDbContextOption();
        }
        #endregion

        #region Test Methods
        [Fact]
        public async void DataBase_UseInMemoryDataBaseAndAddSomeData_ReturnACountOfData()
        {
            using (var context = new SFDbContext(_options))
            {
                await context.AddAsync<ObjectTemplate>(
                    new ObjectTemplate()
                    {
                        Agent = "Test",
                        ApiVersion = "1.0",
                        ClientIP = "127.0.0.1",
                        CreateUserId = 1,
                        Host = "Test",
                        HttpMethod = "POST",
                        Id = 1,
                        RequestId = "22222",
                        RequestUrl = "Rwe",
                        SessionId = "ww",
                        XClientName = "127.0.0.1",
                        XClientVersion = "sad"
                    }
                    );
                await context.AddAsync<ObjectTemplate>(
                    new ObjectTemplate()
                    {
                        Agent = "Test",
                        ApiVersion = "1.0",
                        ClientIP = "127.0.0.1",
                        CreateUserId = 1,
                        Host = "Test",
                        HttpMethod = "POST",
                        Id = 2,
                        RequestId = "22222",
                        RequestUrl = "Rwe",
                        SessionId = "ww",
                        XClientName = "127.0.0.1",
                        XClientVersion = "sad"
                    }
                    );
                await context.AddAsync<ObjectTemplate>(
                    new ObjectTemplate()
                    {
                        Agent = "Test",
                        ApiVersion = "1.0",
                        ClientIP = "127.0.0.1",
                        CreateUserId = 1,
                        Host = "Test",
                        HttpMethod = "POST",
                        Id = 3,
                        RequestId = "22222",
                        RequestUrl = "Rwe",
                        SessionId = "ww",
                        XClientName = "127.0.0.1",
                        XClientVersion = "sad"
                    }
                    );
                await context.AddAsync<ObjectTemplate>(
                    new ObjectTemplate()
                    {
                        Agent = "Test",
                        ApiVersion = "1.0",
                        ClientIP = "127.0.0.1",
                        CreateUserId = 1,
                        Host = "Test",
                        HttpMethod = "POST",
                        Id = 4,
                        RequestId = "22222",
                        RequestUrl = "Rwe",
                        SessionId = "ww",
                        XClientName = "127.0.0.1",
                        XClientVersion = "sad"
                    }
                    );
                await context.SaveChangesAsync();
            }

            using (var context = new SFDbContext(_options))
            {
                var listOfObjects = new List<ObjectTemplate>();
                listOfObjects = await context.ObjectTemplates.ToListAsync();
                Assert.Equal(4, listOfObjects.Count);
            }
        }
        #endregion
    }
}
