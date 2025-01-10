using System.ComponentModel.DataAnnotations;

public class Klient
{
    [Key]
    public int Id { get; set; } // Klucz główny

    [Required]
    [StringLength(50)]
    public string Imie { get; set; } // Imię klienta

    [Required]
    [StringLength(50)]
    public string Nazwisko { get; set; } // Nazwisko klienta

    [EmailAddress]
    public string? Email { get; set; } // E-mail klienta

    [Phone]
    public string? Telefon { get; set; } // Numer telefonu

    // Relacja 1:N z Zamowieniem
    public ICollection<Zamowienie>? Zamowienia { get; set; }
}