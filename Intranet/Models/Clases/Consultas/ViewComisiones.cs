using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Intranet.Models.Clases.Consultas
{
    public class ViewComisiones
    {
        /*
        [DisplayFormat(DataFormatString = "{0:0##}")]
        public int Sucursal { get; set; }
        */
        [Display(Name = "Sucursal")]
        public string Sucursal { get; set; }
        [Key]
        [Display(Name = "Empleado")]
        public string Nombre { get; set; }
        [Display(Name = "Función")]
        public string Funcion { get; set; }
        [Display(Name = "Cobrado en el Período")]
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal Cobrado { get; set; }
        [Display(Name = "Comisión Vendedores")]
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal ComisionVen { get; set; }
        [Display(Name = "Comisión Resto Suc.")]
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal ComisionSuc { get; set; }
        [Display(Name = "A Cobrar del Período")]
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal ACobrar { get; set; }
        [Display(Name = "Resta Cobrar del Período")]
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal RestaCobrar { get; set; }
    }
}