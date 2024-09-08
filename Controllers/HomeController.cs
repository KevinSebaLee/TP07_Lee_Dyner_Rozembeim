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
        Random rnd = new Random();
        int[] ordenPreguntas = GenerateUniqueRandomNumbers(4, rnd);

        ViewBag.OrdenPreguntas = ordenPreguntas;
        ViewBag.PreguntaActual = Juego.ObtenerProximaPregunta();
        ViewBag.RespuestaPregunta = Juego.ObtenerProximasRespuestas(ViewBag.PreguntaActual.IdPregunta);
        ViewBag.nombreUsuario = Juego.Username;
        ViewBag.Puntaje = Juego.PuntajeActual;

        return View("Juego");
    }

    public IActionResult Comenzar(string Username, int Dificultad, int Categoria, string Categorias)
    {
        Juego.CargarPartidas(Username, Dificultad, Categoria);

        Juego.categoriaNombre = Categorias;

        if(Categorias == "Futbol Europeo"){
            Juego.categoriaElegida = "#6B5B95";
        }
        else if(Categorias == "Futbol Sudamericano")
        {
            Juego.categoriaElegida = "#FF6F61";
        }else if(Categorias == "Decada 2000")
        {
            Juego.categoriaElegida = "#88B04B";
        }else
        {
            Juego.categoriaElegida = "#F7CAC9";
        }

        if(Juego.Pregunta.Count() == 0){
            return RedirectToAction("ConfigurarJuego");
        }
        else{
            return RedirectToAction("Jugar");
        }
    }

    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta, int[] ordenPreguntas){
        ViewBag.OrdenPreguntas = ordenPreguntas;
        ViewBag.IdRespuesta = idRespuesta;
        ViewBag.PreguntaActual = Juego.EncontrarPregunta(idPregunta);
        ViewBag.RespuestaPregunta = Juego.ObtenerProximasRespuestas(ViewBag.PreguntaActual.IdPregunta);
        ViewBag.nombreUsuario = Juego.Username;
        ViewBag.Puntaje = Juego.PuntajeActual;
        ViewBag.Correcto = Juego.VerificarRespuestas(idPregunta, idRespuesta);
        
        return View("Respuesta");
    }

    private int[] GenerateUniqueRandomNumbers(int size, Random rnd)
    {
        HashSet<int> orden = new HashSet<int>();
        while (orden.Count < size)
        {
            orden.Add(rnd.Next(size));
        }
        
        int[] result = new int[size];
        orden.CopyTo(result);

        return result;
    }
}
