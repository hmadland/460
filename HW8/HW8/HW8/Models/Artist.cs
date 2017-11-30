namespace HW8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using HW8.Controllers;

    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            ArtWorks = new HashSet<ArtWork>();
        }

        public int ArtistID { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Birth City")]
        public string BirthCity { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Birth Country")]
        public string BirthCountry { get; set; }

        [Required]
        [PastDate]
        [Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }
            
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtWork> ArtWorks { get; set; }


    }
}
