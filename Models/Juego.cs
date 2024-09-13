public static class Juego{
    public static string Username {get; set;}
    public static int PuntajeActual {get; set;}
    public static int CantidadPreguntasCorrectas {get; set;}
    public static string categoriaElegida {get; set;}
    public static string categoriaNombre {get; set;}
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

    public static void CargarPartidas(string username, int Dificultad, int Categoria){
        Username = username;

        Pregunta = BD.ObtenerPreguntas(Dificultad, Categoria);
        Respuesta = BD.ObtenerRespuestas(Pregunta);
    }

    public static Preguntas CrearPreguntas(int idCategoria, int idDificultad, string Enunciado, string Respuesta1, string Respuesta2, string Respuesta3, string Respuesta4, int Opcion1, int Opcion2, int Opcion3, int Opcion4, int Correcta){
        return BD.CrearPreguntas(idCategoria, idDificultad, Enunciado, Respuesta1, Respuesta2, Respuesta3, Respuesta4, Opcion1, Opcion2, Opcion3, Opcion4, Correcta);
    }

    public static Preguntas ObtenerProximaPregunta(){
        Random rnd = new Random();
        int SeleccionarPreguntaRnd = rnd.Next(0, Pregunta.Count());

        return Pregunta[SeleccionarPreguntaRnd];
    }

    public static Preguntas EncontrarPregunta(int idPregunta){
        Preguntas pregunta = Pregunta.FirstOrDefault(p => p.IdPregunta == idPregunta);

        return pregunta;
    }

    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        List<Respuestas> PosiblesRespuestas = new List<Respuestas>();

        foreach(Respuestas r in Respuesta){
            if(r.IdPregunta == idPregunta){
                PosiblesRespuestas.Add(r);
            }
        }

        PosiblesRespuestas = PosiblesRespuestas.OrderBy(x=> Random.Shared.Next()).ToList();

        return PosiblesRespuestas;
    }

    public static bool VerificarRespuestas(int idPregunta, int idRespuesta)
    {
        Respuestas respuestaCorrecta = Respuesta.FirstOrDefault(r => r.IdPregunta == idPregunta && r.Correcta);
        Preguntas pregunta = Pregunta.FirstOrDefault(p => p.IdPregunta == idPregunta);

        Pregunta.Remove(pregunta);

        if (respuestaCorrecta.IdRespuesta == idRespuesta) {
            if(pregunta.IdDificultad == 1){
                PuntajeActual++;
            }
            else if(pregunta.IdDificultad == 2){
                PuntajeActual += 3;
            }
            else{
                PuntajeActual += 5;
            }

            CantidadPreguntasCorrectas++;

            return true;
        } else {
            return false;
        }
    }
}
