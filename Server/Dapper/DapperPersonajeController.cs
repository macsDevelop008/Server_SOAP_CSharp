using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using Server.Model;

namespace Server.Dapper
{
    public class DapperPersonajeController
    {
        private ConnectionDapper dapperMain;
        private MySqlConnection db;


        public DapperPersonajeController() 
        {
            dapperMain = new ConnectionDapper();
            db = dapperMain.MySqlConnection();
        }


        //Insertar
        public bool Insert(Personaje personaje)
        {
            int res;

            string insertSql = "insert into personaje(id, nombre, fuerza," +
                "mana,energia,id_especie,id_jugador,estado_registro, fecha_modificacion)" +
                "values(@id, @nombre, @fuerza," +
                "@mana,@energia,@id_especie,@id_jugador, " +
                "@estado_registro, @fecha_modificacion)";

            res = db.Execute(insertSql,
                    new
                    {
                        id = personaje.Id,
                        nombre = personaje.Nombre,
                        fuerza = personaje.Fuerza,
                        mana = personaje.Mana,
                        energia = personaje.Energia,
                        id_especie = personaje.IdEspecie,
                        id_jugador = personaje.IdJugador,
                        estado_registro = personaje.EstadoRegistro,
                        fecha_modificacion = personaje.FechaModificacion
                    });

            return (res == 1);
        }
        //Actualizar
        public bool Update(Personaje personaje)
        {
            int res;

            string updateSql = "update personaje set " +
                "nombre=@nombre, " +
                "fuerza=@fuerza," +
                "mana=@mana," +
                "energia=@energia," +
                "id_especie=@id_especie," +
                "id_jugador=@id_jugador" +
                "estado_registro = @estado_registro," +
                "fecha_modificacion = @fecha_modificacion " +
                "where id=@id";

            res = db.Execute(updateSql,
                    new
                    {
                        nombre = personaje.Nombre,
                        fuerza = personaje.Fuerza,
                        mana = personaje.Mana,
                        energia = personaje.Energia,
                        id_especie = personaje.IdEspecie,
                        id_jugador = personaje.IdJugador,
                        estado_registro = personaje.EstadoRegistro,
                        fecha_modificacion = personaje.FechaModificacion,
                        id = personaje.Id
                    });

            return (res == 1);
        }
        //Eliminar
        public bool Delete(Personaje personaje)
        {
            int res;

            string deleteSql = "delete from personaje " +
                "where id=@id";

            res = db.Execute(deleteSql,
                    new
                    {
                        id = personaje.Id
                    });
            return (res == 1);
        }

        //Bucar por id
        public Personaje FindbyId(Personaje personaje)
        {
            Personaje res = null;

            /*string findByIdSql = "select * from personaje " +
                "where id=" + personaje.Id;*/
            string findByIdSql = "select * from personaje " +
                "where id=@id";

            var list = db.Query<Personaje>(findByIdSql, new { id = personaje.Id}).ToList();

            foreach (var ae in list)
            {
                Personaje patotruco = new Personaje();
                patotruco.Id = ae.Id;
                patotruco.Nombre = ae.Nombre;
                patotruco.Fuerza = ae.Fuerza;
                patotruco.Mana = ae.Mana;
                patotruco.Energia = ae.Energia;
                patotruco.IdEspecie = FindIdEspecie(patotruco.Id);
                patotruco.IdJugador = FindIdJugador(patotruco.Id);
                patotruco.EstadoRegistro = ae.EstadoRegistro;
                DateTime theDate = DateTime.Now;
                patotruco.FechaModificacion = FindDate(patotruco.Id)/*theDate.ToString("yyyy-MM-dd")*/;
                res = patotruco;
            }

            return res;
        }

        //listar
        public List<Personaje> List()
        {
            List<Personaje> res = new List<Personaje>();

            string findList = "select * from personaje";

            var list = db.Query<Personaje>(findList);

            foreach (var ae in list)
            {
                Personaje patotruco = new Personaje();
                patotruco.Id = ae.Id;
                patotruco.Nombre = ae.Nombre;
                patotruco.Fuerza = ae.Fuerza;
                patotruco.Mana = ae.Mana;
                patotruco.Energia = ae.Energia;
                patotruco.IdEspecie = FindIdEspecie(patotruco.Id);
                patotruco.IdJugador = FindIdJugador(patotruco.Id);
                patotruco.EstadoRegistro = ae.EstadoRegistro;
                DateTime theDate = DateTime.Now;
                patotruco.FechaModificacion = FindDate(patotruco.Id)/*theDate.ToString("yyyy-MM-dd")*/;
                res.Add(patotruco);
            }

            return res;
        }

        private string FindIdEspecie(string id) 
        {
            string res = "";

            string find = "select id_especie from personaje " +
                "where id=" + id;

            res = db.QuerySingle<string>(find);

            return res;
        }

        private string FindIdJugador(string id)
        {
            string res = "";

            string find = "select id_jugador from personaje " +
                "where id=" + id;

            res = db.QuerySingle<string>(find);

            return res;
        }

        private string FindDate(string id)
        {
            string res = "";

            string find = "select fecha_modificacion from personaje " +
                "where id=" + id;

            res = db.QuerySingle<string>(find);

            return res;
        }
    }
}