using System.Data.SqlClient;
using Dapper;

public class BD{
    private static string _connectionString = @"Server=localhost; DataBase=PREGUNTADOS; Trusted_Connection=True;";

    public static List<Categorias> ObtenerCategorias()
    {
        string query = "SELECT * FROM Categorias";
        List<Categorias> Categoria = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            Categoria = db.Query<Categorias>(query).ToList();
        } 

        return Categoria;
    }

    public static List<Dificultades> ObtenerDificultades()
    {
        string query = "SELECT * FROM Dificultades";
        List<Dificultades> Dificultad = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            Dificultad = db.Query<Dificultades>(query).ToList();
        } 

        return Dificultad;
    }

    public static List<Preguntas> ObtenerPreguntas(int Dificultad, int Categorias)
    {
        List<Preguntas> Pregunta = null;
        string sp = "Sp_ObtenerPreguntas";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            Pregunta = db.Query<Preguntas>(sp, new {@idCategoria = Categorias, @idDificultad = Dificultad}, commandType: System.Data.CommandType.StoredProcedure).ToList();
        }

        return Pregunta;
    }

    public static Preguntas CrearPreguntas(int idCategoria, int idDificultad, string Enunciado, string Respuesta1, string Respuesta2, string Respuesta3, string Respuesta4, int Opcion1, int Opcion2, int Opcion3, int Opcion4, int Correcta)
    {
        Preguntas Pregunta = null;
        string sp = "Sp_CrearPreguntas";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            Pregunta = db.QueryFirstOrDefault<Preguntas>(sp, new {@IdCategoria = idCategoria, @IdDificultad = idDificultad, @Enunciado = Enunciado, @Respuesta1 = Respuesta1, @Respuesta2 = Respuesta2, @Respuesta3 = Respuesta3, @Respuesta4 = Respuesta4, @Opcion1 = Opcion1, @Opcion2 = Opcion2, @Opcion3 = Opcion3, @Opcion4 = Opcion4, @Correcta = Correcta}, commandType: System.Data.CommandType.StoredProcedure);
        } 

        return Pregunta;
    }

    public static List<Respuestas> ObtenerRespuestas(List<Preguntas> Preguntas)
    {
        List<Respuestas> Respuesta = new List<Respuestas>();
        string query = "SELECT * FROM Respuestas INNER JOIN Preguntas ON Preguntas.IdPregunta = Respuestas.IdPregunta WHERE Respuestas.IdPregunta = @id";
        
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            foreach (Preguntas pregunta in Preguntas)
            {
                List<Respuestas> respuestasPorPregunta = db.Query<Respuestas>(query, new { @id = pregunta.IdPregunta }).ToList();
                Respuesta.AddRange(respuestasPorPregunta);
            }
        }

        return Respuesta;
    }
}