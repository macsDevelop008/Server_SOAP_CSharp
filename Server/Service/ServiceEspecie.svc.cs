using Dapper;
using MySql.Data.MySqlClient;
using Server.Dapper;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceEspecie" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceEspecie.svc o ServiceEspecie.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceEspecie : IServiceEspecie
    {

        public bool InsertEspecie(Especie especie)
        {
            return dapper().Insert(especie);
        }

        public bool UpdateEspecie(Especie especie)
        {
            return dapper().Update(especie);
        }

        public bool DeleteEspecie(Especie especie)
        {
            return dapper().Delete(especie);
        }

        public Especie FindById(Especie especie)
        {
            return dapper().FindbyId(especie);
        }

        public List<Especie> List() 
        {
            return dapper().List();
        }

        DapperEspecieController dapper()
        {
            return new DapperEspecieController();
        }



    }
}
