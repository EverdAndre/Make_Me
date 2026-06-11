using Make_Me.Models;
using Microsoft.EntityFrameworkCore;

namespace Make_Me.Contexts;

public class FazerContext: DbContext
{
    public DbSet<Tarefa> Tarefas => Set<Tarefa>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=fazer.sqlite3");
    }
}