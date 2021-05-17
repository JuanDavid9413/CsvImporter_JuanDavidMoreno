using BackEnd.PruebaCsvImport.Entities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BackEnd.PruebaCsvImporter.Business.ProcessBusiness
{
    public static class LoadInfoExcelBusinessProcessor
    {
        public static void DowloadDocument(string urlExcel, string routeDirectory, string routeExcel)
        {
            if (!Directory.Exists(routeDirectory))
                Directory.CreateDirectory(routeDirectory);

            if (File.Exists(routeExcel))
                File.Delete(routeExcel);

            using (WebClient web = new WebClient())
                web.DownloadFile(urlExcel, routeExcel);
        }

        public static List<LoadInfoExcel> ReadToExcel(string location)
        {
            List<LoadInfoExcel> loadInfoExcels = new List<LoadInfoExcel>();
            var prueba = File.ReadAllLines(location).Select(a => a.Split(';'));
            foreach (var item in prueba)
            {
                if (item[0] != "PointOfSale")
                    loadInfoExcels.Add(new LoadInfoExcel
                    {
                        PointOfSale = item[0],
                        Product = item[1],
                        Date = Convert.ToDateTime(item[2]),
                        Stock = Convert.ToInt32(item[3])
                    });
            }

            return loadInfoExcels;
        }
    }
}
