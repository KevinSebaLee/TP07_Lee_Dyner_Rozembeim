using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Preguntados.Models;

namespace Preguntados.Controllers;

public class BackOfficeController : Controller
{
    private readonly ILogger<BackOfficeController> _logger;

    public BackOfficeController(ILogger<BackOfficeController> logger)
    {
        _logger = logger;
    }
    public IActionResult CrearPregunta(int idCategoria, int idDificultad, string Enunciado, string Respuesta1, string Respuesta2, string Respuesta3, string Respuesta4, int Opcion1, int Opcion2, int Opcion3, int Opcion4, int Correcta){
        Juego.CrearPreguntas(idCategoria, idDificultad, Enunciado, Respuesta1, Respuesta2, Respuesta3, Respuesta4, Opcion1, Opcion2, Opcion3, Opcion4, Correcta);

        return View("Index");
    }
}