using BackEnd.PruebaCsvImport.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.CsvImporter.Repository.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<LoadInfoExcel> loadInfoExcel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=CsvImpoter; User Id =sa; Password=12345;");
        }
    }
}
