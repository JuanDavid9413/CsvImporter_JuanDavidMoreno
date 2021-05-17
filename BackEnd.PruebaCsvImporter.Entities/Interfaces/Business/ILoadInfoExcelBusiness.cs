using BackEnd.PruebaCsvImporter.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.PruebaCsvImporter.Entities.Interfaces.Business
{
    public interface ILoadInfoExcelBusiness
    {
        Task<ResponseBase<bool>> LoadDataExcel();
    }
}
