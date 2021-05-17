using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackEnd.PruebaCsvImport.Entities.Models
{
    public class LoadInfoExcel
    {
        [Required]
        public string PointOfSale { get; set; }

        [Required]
        public string Product { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
