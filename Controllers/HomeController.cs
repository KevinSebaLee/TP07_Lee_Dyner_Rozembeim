using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Preguntados.Models;

namespace Preguntados.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.Dificultades = Juego.ObtenerDificultades();
        ViewBag.Categorias = Juego.ObtenerCategorias();

        return View();
    }

    public IActionResult Jugar(){
        ViewBag.PreguntaActual = Juego.ObtenerProximaPregunta();
        ViewBag.RespuestaPregunta = Juego.ObtenerProximasRespuestas(ViewBag.PreguntaActual.IdPregunta);
        ViewBag.nombreUsuario = Juego.Username;
        ViewBag.Puntaje = Juego.PuntajeActual;
        ViewBag.NumPregunta = Preguntas.IdPregunta;
        ViewBag.Enunciado = Preguntas.Enunciado

        return View("Juego");
    }

    public IActionResult Comenzar(string Username, int Dificultad, int Categoria)
    {
        Juego.CargarPartidas(Username, Dificultad, Categoria);

        if(!(Juego.Pregunta == null)){
            return RedirectToAction("ConfigurarJuego");
        }
        else{
            return RedirectToAction("Jugar");
        }
    }
}
