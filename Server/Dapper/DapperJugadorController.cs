using MySql.Data.MySqlClient;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace Server.Dapper
{
    public class DapperJugadorController
    {
        private ConnectionDapper dapperMain;
        private MySqlConnection db;

        public DapperJugadorController() 
        {
            dapperMain = new ConnectionDapper();
            db = dapperMain.MySqlConnection();
        }

        //Insertar
        public bool Insert(Jugador jugador)
        {
            int res;

            string insertSql = "insert into jugador(id, cuenta, contraseña," +
                "apodo,email,estado_registro, fecha_modificacion)" +
                "values(@id, @cuenta, @contraseña, @apodo, @email, " +
                "@estado_registro, @fecha_modificacion)";

            res = db.Execute(insertSql,
                    new
                    {
                        id = jugador.Id,
                        cuenta = jugador.Cuenta,
                        contraseña = jugador.Contraseña,
                        apodo = jugador.Apodo,
                        email = jugador.Email,
                        estado_registro = jugador.EstadoRegistro,
                        fecha_modificacion = jugador.FechaModificacion
                    });

            return (res == 1);
        }
        //Actualizar
        public bool Update(Jugador jugador)
        {
            int res;

            string updateSql = "update jugador set cuenta = @cuenta, " +
                "contraseña = @contraseña," +
                "apodo = @apodo," +
                "email = @email," +
                "estado_registro = @estado_registro," +
                "fecha_modificacion = @fecha_modificacion " +
                "where id=@id";

            res = db.Execute(updateSql,
                    new
                    {
                        cuenta = jugador.Cuenta,
                        contraseña = jugador.Contraseña,
                        apodo = jugador.Apodo,
                        email = jugador.Email,
                        estado_registro = jugador.EstadoRegistro,
                        fecha_modificacion = jugador.FechaModificacion,
                        id = jugador.Id
                    });

            return (res == 1);
        }
        //Eliminar
        public bool Delete(Jugador jugador)
        {
            int res;

            string deleteSql = "delete from jugador " +
                "where id=@id";

            res = db.Execute(deleteSql,
                    new
                    {
                        id = jugador.Id
                    });
            return (res == 1);
        }

        //Bucar por id
        public Jugador FindbyId(Jugador jugador)
        {
            Jugador res = null;

            string findByIdSql = "select * from jugador " +
                "where id=" + jugador.Id;

            var list = db.Query<Jugador>(findByIdSql);

            foreach (var ae in list)
            {
                Jugador patotruco = new Jugador();
                patotruco.Id = ae.Id;
                patotruco.Cuenta = ae.Cuenta;
                patotruco.Contraseña = ae.Contraseña;
                patotruco.Apodo = ae.Apodo;
                patotruco.Email = ae.Apodo;
                patotruco.EstadoRegistro = ae.EstadoRegistro;
                DateTime theDate = DateTime.Now;
                patotruco.FechaModificacion = FindDate(ae.Id)/*theDate.ToString("yyyy-MM-dd")*/;
                res = patotruco;
            }

            return res;
        }

        //listar
        public List<Jugador> List()
        {
            List<Jugador> res = new List<Jugador>();

            string findByIdSql = "select * from jugador";

            var list = db.Query<Jugador>(findByIdSql);

            foreach (var ae in list)
            {
                Jugador patotruco = new Jugador();
                patotruco.Id = ae.Id;
                patotruco.Cuenta = ae.Cuenta;
                patotruco.Contraseña = ae.Contraseña;
                patotruco.Apodo = ae.Apodo;
                patotruco.Email = ae.Apodo;
                patotruco.EstadoRegistro = ae.EstadoRegistro;
                DateTime theDate = DateTime.Now;
                patotruco.FechaModificacion = FindDate(ae.Id)/*theDate.ToString("yyyy-MM-dd")*/;
                res.Add(patotruco);
            }

            return res;
        }

        private string FindDate(string id)
        {
            string res = "";

            string find = "select fecha_modificacion from jugador " +
                "where id=" + id;

            res = db.QuerySingle<string>(find);

            return res;
        }
    }
}
