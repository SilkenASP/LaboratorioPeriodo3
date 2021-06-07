namespace LaboratorioPWA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("juego")]
    public partial class juego
    {
        [Key]
        public int idjuego { get; set; }

        [StringLength(75)]
        public string nomJuego { get; set; }

        public int? idcategoria { get; set; }

        public double? precio { get; set; }

        public int? existencias { get; set; }

        [StringLength(200)]
        public string imagen { get; set; }

        public virtual categoria categoria { get; set; }
    }
}
