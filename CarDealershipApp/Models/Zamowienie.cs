using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Zamowienie
{
    [Key]
    public int Id { get; set; } // Klucz główny

    [Required]
    public int KlientId { get; set; } // Klucz obcy do Klienta

    [ForeignKey("KlientId")]
    public Klient? Klient { get; set; } // Nawigacyjna właściwość (opcjonalna)

    [Required]
    public int SamochodId { get; set; } // Klucz obcy do Samochodu

    [ForeignKey("SamochodId")]
    public Samochod? Samochod { get; set; } // Nawigacyjna właściwość (opcjonalna)

    [Required]
    public int SprzedawcaId { get; set; } // Klucz obcy do Sprzedawcy

    [ForeignKey("SprzedawcaId")]
    public Sprzedawca? Sprzedawca { get; set; } // Nawigacyjna właściwość (opcjonalna)
}