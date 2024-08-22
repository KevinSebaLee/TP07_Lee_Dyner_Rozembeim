public static class Juego{
    static string Username {get; set;}
    static int PuuntajeActual {get; set;}
    static int CantidadPreguntasCorrectas {get; set;}
    static List<Preguntas> Pregunta {get; set;}
    static List<Respuestas> Respuesta {get; set;}

    public static void InicializarJuego(){
        Username = null;
        PuuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
    }

    public static List<Categorias> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }

    public static List<Dificultades> ObtenerDificultades(){
        return BD.ObtenerDificultades();
    }

    public static void CargarPartidas(string Username, int Dificultad, int Categoria){
        Pregunta = BD.ObtenerDificultades(Dificultad, Categoria);
        Respuesta = BD.ObtenerRespuestas(Pregunta);
    }

    public static Preguntas ObtenerProximaPregunta(){
        Random rnd = new Random();
        int SeleccionarPreguntaRnd = rnd.Next(0, Pregunta.Count());

        return Pregunta[SeleccionarPreguntaRnd];
    }

    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta){
        return Respuesta[idPregunta];
    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta){
        if(Pregunta(idRespuesta).IdRespuesta == Respuesta(idRespuesta).IdRespuesta){
            PuuntajeActual++;
            Pregunta.RemoveAt(idPregunta);
            Pregunta.RemoveAt(idRespuesta);

            return true;
        }
        else{
            return false;
        }
    }
}