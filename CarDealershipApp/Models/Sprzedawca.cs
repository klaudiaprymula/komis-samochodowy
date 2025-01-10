using System.ComponentModel.DataAnnotations;

public class Sprzedawca
{
    [Key]
    public int Id { get; set; } // Klucz główny

    [Required]
    [StringLength(50)]
    public string Imie { get; set; } // Imię sprzedawcy

    [Required]
    [StringLength(50)]
    public string Nazwisko { get; set; } // Nazwisko sprzedawcy

    [Required]
    [EmailAddress]
    public string Email { get; set; } // E-mail sprzedawcy

    [Phone]
    public string? Telefon { get; set; } // Telefon sprzedawcy

    [Required]
    public DateTime DataZatrudnienia { get; set; } // Data zatrudnienia

    // Relacja 1:N z Zamowieniem
    public ICollection<Zamowienie>? Zamowienia { get; set; }
}