using System.Data.SqlClient;
using Dapper;

public class BD{
    private static string _connectionString = @"Server=localhost; DataBase=PREGUNTADOS; Trusted_Connection=True;";

    public static ObtenerCategorias()
    {
        string query = "SELECT * FROM Categorias";
        List<Categorias> Categorias = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            Categorias = db.QueryFirstOrDefault<Categorias>(query);
        } 
    }

    public static ObtenerDificultades()
    {
        string query = "SELECT * FROM Dificultades";
        List<Dificultades> Dificultades = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            Dificultades = db.QueryFirstOrDefault<Dificultades>(query);
        } 
    }

    public static ObtenerDificultades(int Dificultad, int Categorias){
        string query = "SELECT * FROM Preguntas INNER JOIN Dificultades ON Preguntas.IdDificultad = Preguntas.IdDificultad INNER JOIN Categorias ON Preguntas.IdCategoria = Categorias.IdCategoria WHERE IdDificultad = @idDificultad AND IdCategoria = @idCategoria";
        List<Preguntas> Preguntas = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            Preguntas = db.QueryFirstOrDefault<Preguntas>(query, new{idDificultad = Dificultad}, new{IdCategoria = Categorias});
        } 
    }

    public static ObtenerRespuestas(List<Preguntas> Preguntas){
        string query = "SELECT * FROM Respuestas INNER JOIN Preguntas ON Preguntas.IdPregunta = Respuesta.IdPregunta WHERE IdPregunta = @id";
        List<Respuestas> Respuestaas = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            Preguntas = db.QueryFirstOrDefault<Preguntas>(query, new{IdPregunta = Preguntas.IdPregunta});
        } 
    } 
}