using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Pizzas.API.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=A-LUM-11;DataBase=Database;Trusted_Connection=True;";
        //private static string _connectionString = @"Server=DESKTOP-VMP7PL7;DataBase=BDWebCursos;Trusted_Connection=True;";

         public static Pizza ConsultaPizzas (int IdPizza){
           Pizza PizzaBuscada = null;
           string sql = "SELECT * FROM Pizzas WHERE Id = @p";
           using(SqlConnection db =  new SqlConnection(_connectionString)){
               PizzaBuscada = db.QueryFirstOrDefault<Pizza>(sql, new {p = IdPizza});
           }
           return PizzaBuscada;
        }

        public static void AgregarPizza (Pizza Pizza){
            string sql = "INSERT INTO Pizzas( Id, Nombre, LibreGluten, Importe, Descripcion) VALUES ( @pId, @pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
            using(SqlConnection db =  new SqlConnection(_connectionString)){
                db.Execute(sql, new{ pId = Pizza.Id, pNombre = Pizza.Nombre, pLibreGluten = Pizza.LibreGluten, pImporte = Pizza.Importe, pDescripcion = Pizza.Descripcion});
            }
        }
        public static bool ModificarPizza (int DNI, int NumeroTramite){
           bool Voto = false;
           string sql = "UPDATE Personas SET Voto='true', FechaVoto='2020-01-24' WHERE DNI = @dnib AND NumeroTramite = @numt ";
           using(SqlConnection db =  new SqlConnection(_connectionString)){
               Voto = db.QueryFirstOrDefault<bool>(sql, new {dnib = DNI, numt = NumeroTramite});
           }
           return Voto;
        }

         public static int EliminarPizza (int Id){
           int Registro = 0;
           string sql = "DELETE * FROM Pizza WHERE Id = @p ";
           using(SqlConnection db =  new SqlConnection(_connectionString)){
               Registro = db.Execute(sql, new {p = Id});
           }
           return Registro;
        }
    
    
    }
}