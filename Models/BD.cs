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
            Pregunta = db.Query<Preguntas>(sp, new {@idCategoria = Categorias}, commandType: System.Data.CommandType.StoredProcedure).ToList();
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

                Console.WriteLine(respuestasPorPregunta);
            }
        }

        return Respuesta;
    }
}