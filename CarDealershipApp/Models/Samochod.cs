using System.ComponentModel.DataAnnotations;

public class Samochod
{
    [Key]
    public int Id { get; set; } // Klucz główny

    [Required]
    [StringLength(100)]
    public string Marka { get; set; } // Marka samochodu

    [Required]
    [StringLength(100)]
    public string Model { get; set; } // Model samochodu

    [Required]
    public decimal Cena { get; set; } // Cena samochodu

    [Required]
    public int RokProdukcji { get; set; } // Rok produkcji

    [Required]
    public bool Dostepnosc { get; set; } = true; // Czy samochód jest dostępny

    // Relacja 1:1 z Zamowieniem
    public Zamowienie? Zamowienie { get; set; }
}