using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Intranet.Models.Clases
{
    [Table("Sucur")]
    public class Sucursal
    {
        [Key]
        [Display(Name = "Código")]
        [StringLength(3)]
        public string CodSuc { get; set; }

        [Display(Name = "Sucursal")]
        [StringLength(30)]
        public string dessuc { get; set; }

        [Display(Name = "Estado")]
        public Boolean inactivo { get; set; }
    }
}


 
    
