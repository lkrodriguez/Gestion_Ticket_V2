namespace S_Tickets.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        
        public Usuario()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public bool Activo { get; set; }


        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
