namespace Bank2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pracownicy")]
    public partial class Pracownicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pracownicy()
        {
            Kredyty = new HashSet<Kredyty>();
            Lokaty = new HashSet<Lokaty>();
        }

        [Key]
        [Column("Id Pracownika")]
        public int Id_Pracownika { get; set; }

        [Column("Imię pracownika")]
        [Required]
        [StringLength(50)]
        public string Imię_pracownika { get; set; }

        [Column("Nazwisko pracownika")]
        [Required]
        [StringLength(50)]
        public string Nazwisko_pracownika { get; set; }

        [Required]
        [StringLength(50)]
        public string PESEL { get; set; }

        [Column(TypeName = "money")]
        public decimal Wynagrodzenie { get; set; }

        [Column("Data zatrudnienia", TypeName = "date")]
        public DateTime Data_zatrudnienia { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? Telefon { get; set; }

        public bool? aktywny { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kredyty> Kredyty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lokaty> Lokaty { get; set; }
    }
}