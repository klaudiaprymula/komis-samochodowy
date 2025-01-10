using Microsoft.EntityFrameworkCore;

public class KomisContext : DbContext
{
    public KomisContext(DbContextOptions<KomisContext> options) : base(options) { }

    public DbSet<Samochod> Samochody { get; set; }
    public DbSet<Klient> Klienci { get; set; }
    public DbSet<Zamowienie> Zamowienia { get; set; }
    public DbSet<Sprzedawca> Sprzedawcy { get; set; }
}
