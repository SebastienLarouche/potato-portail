using PotatoPortail.Models.eSports;

namespace PotatoPortail.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rang
    {
        public Rang()
        {

        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Rang")]
        public string NomRang { get; set; }

        [Required]
        [Display(Name = "Abr�viation")]
        [StringLength(6, MinimumLength = 2, ErrorMessage = "L'abr�viation doit avoir entre 2 et 6 caract�res.")]
        public string Abreviation { get; set; }

        [Required]
        [Display(Name = "Hi�rarchie")]
        public int Hierarchie { get; set; }

        [Display(Name = "Jeu")]
        public int IdJeu { get; set; }

        public virtual Jeu Jeu { get; set; }

        public virtual ICollection<HistoriqueRang> HistoriqueRang { get; set; }
    }
}
