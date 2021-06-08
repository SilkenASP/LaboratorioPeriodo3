using LaboratorioPWA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioPWA.Models
{
    public class localJuego
    {
        private readonly ICrudGeneral<categoria> db = new RCategoria();

        public int idJuego { get; set; }
        public string nomJuego { get; set; }
        public double precio { get; set; }
        public int existencias { get; set; }
        public string imageGame { get; set; }
        public virtual categoria categoria { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}