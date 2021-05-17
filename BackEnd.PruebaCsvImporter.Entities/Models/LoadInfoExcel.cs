using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackEnd.PruebaCsvImport.Entities.Models
{
    public class LoadInfoExcel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

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
