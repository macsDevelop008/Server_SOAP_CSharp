using MySql.Data.MySqlClient;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace Server.Dapper
{
    public class DapperEspecieController
    {
        private ConnectionDapper dapperMain;
        private MySqlConnection db;
        public DapperEspecieController() 
        {
            dapperMain = new ConnectionDapper();
            db = dapperMain.MySqlConnection();
        }

        //Insertar
        public bool Insert(Especie especie) 
        {
            /*Especie especie = new Especie();
            especie.Id = "323";
            especie.Nombre = "añañin";
            especie.EstadoRegistro = 1;
            especie.FechaModificacion = theDate.ToString("yyyy-MM-dd H:mm:ss");*/

            int res;

            string insertSql = "insert into especie(id, nombre, estado_registro, fecha_modificacion)" +
                "values(@id, @nombre, @estado_registro, @fecha_modificacion)";
          
            res = db.Execute(insertSql,
                    new
                    {
                        id = especie.Id,
                        nombre = especie.Nombre,
                        estado_registro = especie.EstadoRegistro,
                        fecha_modificacion = especie.FechaModificacion
                    }); 

            return (res==1);
        }
        //Actualizar
        public bool Update(Especie especie)
        {
            /*Especie especie = new Especie();
            especie.Id = "323";
            especie.Nombre = "dificaana";
            especie.EstadoRegistro = 1;
            DateTime theDate = DateTime.Now;
            especie.FechaModificacion = theDate.ToString("yyyy-MM-dd H:mm:ss");*/

            int res;

            string updateSql = "update especie set nombre = @nombre, " +
                "estado_registro = @estado_registro, " +
                "fecha_modificacion = @fecha_modificacion " +
                "where id=@id";

            res = db.Execute(updateSql,
                    new
                    {
                        nombre = especie.Nombre,
                        estado_registro = especie.EstadoRegistro,
                        fecha_modificacion = especie.FechaModificacion,
                        id = especie.Id
                    });

            return (res == 1);
        }
        //Eliminar
        public bool Delete(Especie especie)
        {
            /*Especie especie = new Especie();
            especie.Id = "123";*/

            int res;

            string deleteSql = "delete from especie " +
                "where id=@id";

            res = db.Execute(deleteSql,
                    new
                    {
                        id = especie.Id
                    });
            return (res == 1);
        }

        //Bucar por id
        public Especie FindbyId(Especie especie)
        {
            /*Especie especie = new Especie();
            especie.Id = "223";*/

            Especie res = null;

            string findByIdSql = "select * from especie " +
                "where id="+ especie.Id;

            var list = db.Query<Especie>(findByIdSql);

            foreach (var ae in list)
            {
                Especie patotruco = new Especie();
                patotruco.Id = ae.Id;
                patotruco.Nombre = ae.Nombre;
                patotruco.EstadoRegistro = ae.EstadoRegistro;
                DateTime theDate = DateTime.Now;
                patotruco.FechaModificacion = FindDate(ae.Id)/*theDate.ToString("yyyy-MM-dd")*/;
                res = patotruco;
            }

            return res;
        }

        //listar
        public List<Especie> List()
        {
            List<Especie> res = new List<Especie>();

            string findByIdSql = "select * from especie";

            var list = db.Query<Especie>(findByIdSql);

            foreach (var ae in list)
            {
                Especie patotruco = new Especie();
                patotruco.Id = ae.Id;
                patotruco.Nombre = ae.Nombre;
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

            string find = "select fecha_modificacion from especie " +
                "where id=" + id;

            res = db.QuerySingle<string>(find);

            return res;
        }
    }
}