public static class Juego{
    private static string Username {get; set;}
    private static int PuntajeActual {get; set;}
    private static int CantidadPreguntasCorrectas {get; set;}
    public static List<Preguntas> Pregunta {get; set;}
    public static List<Respuestas> Respuesta {get; set;}

    public static void InicializarJuego(){
        Username = null;
        PuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
    }

    public static List<Categorias> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }

    public static List<Dificultades> ObtenerDificultades(){
        return BD.ObtenerDificultades();
    }

    public static void CargarPartidas(string Username, int Dificultad, int Categoria){
        Pregunta = BD.ObtenerPreguntas(Dificultad, Categoria);
        Respuesta = BD.ObtenerRespuestas(Pregunta);
    }

    public static Preguntas ObtenerProximaPregunta(){
        Random rnd = new Random();
        int SeleccionarPreguntaRnd = rnd.Next(0, Pregunta.Count());

        return Pregunta[SeleccionarPreguntaRnd];
    }

    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        List<Respuestas> PosiblesRespuestas = new List<Respuestas>();

        foreach(Respuestas r in Respuesta){
            if(r.IdPregunta == idPregunta){
                PosiblesRespuestas.Add(r);
            }
        }

        return PosiblesRespuestas;
    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta){
        if(Pregunta[idPregunta].IdPregunta == Respuesta[idPregunta].IdPregunta){
            PuntajeActual++;
            Pregunta.RemoveAt(idPregunta);
            Pregunta.RemoveAt(idRespuesta);

            return true;
        }
        else{
            return false;
        }
    }
}