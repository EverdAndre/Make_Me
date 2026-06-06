using Make_Me.Models;
using Microsoft.EntityFrameworkCore;

namespace Make_Me.Contexts;

public class FazerContext: DbContext
{
    public DbSet<Fazer> Tarefas => Set<Fazer>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=fazer.sqlite3");
    }
}