using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BackEnd.PruebaCsvImporter.Entities.Interfaces.Repository;
using BackEnd.PruebaCsvImport.Entities.Models;
using BackEnd.PruebaCsvImporter.Business;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace BackEnd.PruebaCsvImporter.Test.Business
{
    [TestClass]
    public class LoadExcelInfoBusinessTest
    {
        private readonly Mock<ILoadInfoExcelRepository> _repository = new Mock<ILoadInfoExcelRepository>();
        private readonly Mock<ILogger<LoadInfoExcelBusiness>> _logger = new Mock<ILogger<LoadInfoExcelBusiness>>();
        private readonly Mock<IConfiguration> _config = new Mock<IConfiguration>();
        private readonly Mock<IConfigurationSection> _configSectionOne = new Mock<IConfigurationSection>();
        private readonly Mock<IConfigurationSection> _configSectionTwo = new Mock<IConfigurationSection>();
        private readonly Mock<IConfigurationSection> _configSectionThree = new Mock<IConfigurationSection>();
        private LoadInfoExcelBusiness loadInfoExcelBusiness;
        public LoadExcelInfoBusinessTest()
        {
            loadInfoExcelBusiness = new LoadInfoExcelBusiness(_logger.Object, _repository.Object, _config.Object);
        }

        [TestMethod]
        [DataRow(1, 400, DisplayName = "LoadDataExcel_BadRequest")]
        [DataRow(2, 500, DisplayName = "LoadDataExcel_InternalServerError")]
        //[DataRow(3, 200, DisplayName = "LoadDataExcel_Done")]
        public async Task LoadDataExcel(int position, int status)
        {
            switch (position)
            {
                case 1:
                    _config.Setup(x => x.GetSection("URL")).Returns(_configSectionOne.Object);
                    _config.Setup(x => x.GetSection("DirectoryFolder")).Returns(_configSectionTwo.Object);
                    _config.Setup(x => x.GetSection("NameExcel")).Returns(_configSectionThree.Object);
                    break;
                case 2:
                    _configSectionOne.Setup(x => x.Value).Returns("https://storage10082020.blob.core.windows.net/y9ne9ilzmfld");
                    _config.Setup(x => x.GetSection("URL")).Returns(_configSectionOne.Object);
                    _configSectionTwo.Setup(x => x.Value).Returns("C:\\PruebaCsvImporter\\");
                    _config.Setup(x => x.GetSection("DirectoryFolder")).Returns(_configSectionTwo.Object);
                    _configSectionThree.Setup(x => x.Value).Returns("Stock.CSV");
                    _config.Setup(x => x.GetSection("NameExcel")).Returns(_configSectionThree.Object);
                    break;
                case 3:
                    _configSectionOne.Setup(x => x.Value).Returns("https://storage10082020.blob.core.windows.net/y9ne9ilzmfld/Stock.CSV");
                    _config.Setup(x => x.GetSection("URL")).Returns(_configSectionOne.Object);
                    _configSectionTwo.Setup(x => x.Value).Returns("C:\\PruebaCsvImporter\\");
                    _config.Setup(x => x.GetSection("DirectoryFolder")).Returns(_configSectionTwo.Object);
                    _configSectionThree.Setup(x => x.Value).Returns("Stock.CSV");
                    _config.Setup(x => x.GetSection("NameExcel")).Returns(_configSectionThree.Object);
                    _repository.Setup(l => l.Add(It.IsAny<List<LoadInfoExcel>>()))
                        .Returns(Task.FromResult(true));
                    break;
            }

            var response = await loadInfoExcelBusiness.LoadDataExcel();
            Assert.AreEqual(status, response.Code);
        }
    }
}
