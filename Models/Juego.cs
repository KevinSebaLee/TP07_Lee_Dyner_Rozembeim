public static class Juego{
    static string Username {get; set;}
    static int PuuntajeActual {get; set;}
    static int CantidadPreguntasCorrectas {get; set;}
    static List<Preguntas> Preguntas {get; set;}
    static List<Respuestas> Respuestas {get; set;}

    static void InicializarJuego(){
        Username = null;
        PuuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
    }

    static List<Categorias> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }

    static List<Dificultades> ObtenerDificultades(){
        return BD.ObtenerDificultades();
    }
}