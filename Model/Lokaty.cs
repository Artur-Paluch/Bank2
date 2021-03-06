










namespace Bank2.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Lokaty")]

    public partial class Lokaty
    {

        [Key]

        [Column("Id Lokaty")]

        public int Id_Lokaty { get; set; }


        [Column("Wysokość lokaty", TypeName = "money")]

        public decimal Wysokość_lokaty { get; set; }


        public int? Klient { get; set; }


        [Column("Id Rodzaju lokaty")]

        public int? Id_Rodzaju_lokaty { get; set; }


        [Column("Lokaty udzielił")]

        public int? Lokaty_udzielił { get; set; }


        [Column("Data założenia", TypeName = "date")]

        public DateTime? Data_założenia { get; set; }


        public bool aktywny { get; set; }


        public virtual Klienci Klienci { get; set; }


        public virtual Rodzaje_lokat Rodzaje_lokat { get; set; }


        public virtual Pracownicy Pracownicy { get; set; }

    }
}
