using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Make_Me.Models;

public class Fazer
{
    public int Id { get; set; }
    public string Titulo {get; set;}= string.Empty;
    public DateTime CriadoEm{get; set;}
    public DateOnly DataInicio{get; set;}
    public DateOnly? DataFim{get; set;}
}
