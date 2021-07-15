namespace S_Tickets.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int id { get; set; }

        public DateTime FechaGeneracion { get; set; }

        public int idEstado { get; set; }

        public int idUsuario { get; set; }

        [Required]
        public string Descripsion { get; set; }

        public int idResponsable { get; set; }

        public string Solucion { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Resposable Resposable { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
