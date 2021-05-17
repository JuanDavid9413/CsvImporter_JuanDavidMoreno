using BackEnd.PruebaCsvImport.Entities.Models;
using BackEnd.PruebaCsvImporter.Business.ProcessBusiness;
using BackEnd.PruebaCsvImporter.Entities.Interfaces.Business;
using BackEnd.PruebaCsvImporter.Entities.Interfaces.Repository;
using BackEnd.PruebaCsvImporter.Entities.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.PruebaCsvImporter.Business
{
    public class LoadInfoExcelBusiness : ILoadInfoExcelBusiness
    {
        private readonly ILogger<LoadInfoExcelBusiness> _log;
        private readonly ILoadInfoExcelRepository _loadInfoExcelRepository;
        private readonly IConfiguration _config;

        public LoadInfoExcelBusiness(ILogger<LoadInfoExcelBusiness> log, ILoadInfoExcelRepository loadInfoExcelRepository, IConfiguration config)
        {
            _log = log;
            _loadInfoExcelRepository = loadInfoExcelRepository;
            _config = config;
        }

        public async Task<ResponseBase<bool>> LoadDataExcel()
        {
            ResponseBase<bool> result = new ResponseBase<bool>();
            try
            {
                string urlExcel = _config.GetValue<string>("URL");
                string routeDirectory = _config.GetValue<string>("DirectoryFolder");
                string routeExcel = $@"{routeDirectory}{_config.GetValue<string>("NameExcel")}";
                if (!string.IsNullOrEmpty(urlExcel) && !string.IsNullOrEmpty(routeDirectory) && !string.IsNullOrEmpty(routeExcel))
                {
                    _log.LogInformation("We're downloading the file");
                    LoadInfoExcelBusinessProcessor.DowloadDocument(urlExcel, routeDirectory, routeExcel);
                    _log.LogInformation("Great.. Download the file, now, We change the information in DB");
                    List<LoadInfoExcel> loadInfoExcels = LoadInfoExcelBusinessProcessor.ReadToExcel(routeExcel);
                    if (loadInfoExcels.Count() != 0)
                    {
                        if (await SaveInfoExcel(loadInfoExcels))
                        {
                            result.Data = true;
                            result.Code = (int)HttpStatusCode.OK;
                            result.Message = "Load function correctly =D";
                        }
                        else
                        {
                            result.Data = false;
                            result.Code = (int)HttpStatusCode.BadRequest;
                            result.Message = "Opps.... someting failure to add information in BD, Please check the connect. =(";
                        }
                    }
                }
                else
                {
                    result.Data = false;
                    result.Code = (int)HttpStatusCode.BadRequest;
                    result.Message = "Opps.... check the appsettings configuration";
                }
            }
            catch (Exception ex)
            {
                result.Data = false;
                result.Code = (int)HttpStatusCode.InternalServerError;
                result.Message = ex.Message;
            }
            return result;
        }

        private async Task<bool> SaveInfoExcel(List<LoadInfoExcel> loadInfoExcels)
        {
            double count = 5.5;
            bool result = false;
            do
            {
                _log.LogInformation($"{ count }%.........");
                var item = loadInfoExcels.Take(1000000);
                result = await _loadInfoExcelRepository.Add(item.ToList());
                loadInfoExcels = loadInfoExcels.Skip(1000000).ToList();
                count = count + 5.5;
            } while (loadInfoExcels.Count() != 0);
            _log.LogInformation($"100%......... =D");

            return result;
        }
    }
}
