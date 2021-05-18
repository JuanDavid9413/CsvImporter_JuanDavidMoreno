using BackEnd.PruebaCsvImport.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.PruebaCsvImporter.Entities.Interfaces.Repository
{
    public interface ILoadInfoExcelRepository
    {
        Task<bool> Add(List<LoadInfoExcel> loadInfoExcel);
        //Task<bool> Delete(List<LoadInfoExcel> loadInfoExcel);
        Task<bool> Delete();
        Task<List<LoadInfoExcel>> GetDistict();
        Task<List<LoadInfoExcel>> GetFilter(Expression<Func<LoadInfoExcel, bool>> expression);

    }
}
