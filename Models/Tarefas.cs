using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Make_Me.Models;

public class Tarefa
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(100,MinimumLength = 5, ErrorMessage ="{0} Minimo 5 e maximo 100 Caracteres")]
    public string Titulo { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime? DataConclusao { get; set; }

    [Required(ErrorMessage = "Campo Obrigatorio")]
    public DateOnly? DataFim { get; set; }
}
