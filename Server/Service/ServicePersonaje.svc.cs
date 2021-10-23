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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicePersonaje" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicePersonaje.svc o ServicePersonaje.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicePersonaje : IServicePersonaje
    {
        public bool DeletePersonaje(Personaje personaje)
        {
            return dapper().Delete(personaje);
        }

        public Personaje FindById(Personaje personaje)
        {
            return dapper().FindbyId(personaje);
        }

        public bool InsertPersonaje(Personaje personaje)
        {
            return dapper().Insert(personaje);
        }

        public List<Personaje> List()
        {
            return dapper().List();
        }

        public bool UpdatePersonaje(Personaje personaje)
        {
            return dapper().Update(personaje);
        }

        DapperPersonajeController dapper()
        {
            return new DapperPersonajeController();
        }
    }
}
