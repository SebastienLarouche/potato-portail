using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PotatoPortail.Models.eSports
{
    public partial class Entraineur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entraineur()
        {
            Equipes = new HashSet<Equipe>();
        }

        public string NomComplet => PrenomEntraineur + NomEntraineur;

        public int Id { get; set; }

        [Required]
        public string NomEntraineur { get; set; }

        [Required]
        public string PrenomEntraineur { get; set; }

        [Required]
        public string PseudoEntraineur { get; set; }

        [Required]
        public string NumeroTelephone { get; set; }

        [Required]
        public string AdresseCourriel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipe> Equipes { get; set; }
    }
}
