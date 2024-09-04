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

        Console.WriteLine(ViewBag.PreguntaActual);

        return View("Juego");
    }

    public IActionResult Comenzar(string Username, int Dificultad, int Categoria)
    {
        Juego.CargarPartidas(Username, Dificultad, Categoria);

        if(Juego.Pregunta.Count() == 0){
            return RedirectToAction("ConfigurarJuego");
        }
        else{
            return RedirectToAction("Jugar");
        }
    }

    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        ViewBag.Correcto = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        
        return View("Respuesta");
    }
}
