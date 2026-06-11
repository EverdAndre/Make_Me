using Make_Me.Contexts;
using Make_Me.Models;
using Microsoft.AspNetCore.Mvc;

namespace Make_Me.controllers;

public class FazerController : Controller
{
    private readonly FazerContext _context;

    public FazerController(FazerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de Tarefas";
        var tarefas = _context.Tarefas.ToList();
        return View(tarefas);
    }

    //exibe formulario
    public IActionResult Create()
    {
        ViewData["Title"] = "Nova Tarefa";
        return View("Formulario", new Tarefa());
    }

    // Envia dados pro bd
    [HttpPost]
    public IActionResult Create(Tarefa tarefa)
    {
        if (ModelState.IsValid)
        {
            tarefa.CriadoEm = DateTime.Now;
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Nova Tarefa";
        return View("Formulario", tarefa);
    }

    public IActionResult Editar(int Id)
    {
        var tarefa = _context.Tarefas.Find(Id);
        if (tarefa == null)
        {
            return NotFound();
        }

        ViewData["Title"] = "Editar Tarefa";
        return View("Formulario", tarefa);
    }

    [HttpPost]
    public IActionResult Editar(Tarefa tarefa)
    {
        var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
        if (tarefaBanco == null)
        {
            return NotFound();
        }

        tarefaBanco.Titulo = tarefa.Titulo;
        tarefaBanco.DataFim = tarefa.DataFim;

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Excluir(int Id)
    {
        var tarefa = _context.Tarefas.Find(Id);
        if (tarefa == null)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewData["Title"] = "Excluir Tarefa";
        return View(tarefa);
    }

    [HttpPost]
    public IActionResult Excluir(Tarefa tarefa)
    {
        var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
        if (tarefaBanco == null)
        {
            return RedirectToAction(nameof(Index));
        }
        _context.Tarefas.Remove(tarefaBanco);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Concluir(int Id)
    {
        var tarefa = _context.Tarefas.Find(Id);
        if (tarefa == null)
        {
            return NotFound();
        }

        tarefa.DataConclusao = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Concluir(Tarefa tarefa)
    {
        var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
        if (tarefaBanco == null)
        {
            return NotFound();
        }

        tarefaBanco.DataConclusao = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
