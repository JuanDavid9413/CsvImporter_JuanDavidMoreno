using BackEnd.CsvImporter.Repository.Context;
using BackEnd.PruebaCsvImport.Entities.Models;
using BackEnd.PruebaCsvImporter.Entities.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackEnd.CsvImporter.Repository.Database
{
    public class LoadInfoExcelRepository : ILoadInfoExcelRepository
    {
        public async Task<bool> Add(List<LoadInfoExcel> loadInfoExcel)
        {
            using (var context = new ApplicationContext())
            {
                await context.BulkInsertAsync(loadInfoExcel);
                var resp = context.BulkSaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(List<LoadInfoExcel> loadInfoExcel)
        {
            using (var context = new ApplicationContext())
            {
                await context.BulkDeleteAsync(loadInfoExcel);
                var resp = context.BulkSaveChangesAsync();
                return true;
            }
        }

        public async Task<List<LoadInfoExcel>> GetAll()
        {
            using (var context = new ApplicationContext())
            {
                return context.loadInfoExcel.ToList();
            }
        }

        public async Task<List<LoadInfoExcel>> GetFilter(Expression<Func<LoadInfoExcel, bool>> expression)
        {
            using (var context = new ApplicationContext())
            {
                return context.loadInfoExcel.ToList();
            }
        }
    }
}
