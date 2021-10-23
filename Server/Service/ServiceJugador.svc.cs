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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceJugador" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceJugador.svc o ServiceJugador.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceJugador : IServiceJugador
    {
        public bool DeleteJugador(Jugador jugador)
        {
            return dapper().Delete(jugador);
        }

        public Jugador FindById(Jugador jugador)
        {
            return dapper().FindbyId(jugador);
        }

        public bool InsertJugador(Jugador jugador)
        {
            return dapper().Insert(jugador);
        }

        public List<Jugador> List()
        {
            return dapper().List();
        }

        public bool UpdateJugador(Jugador jugador)
        {
            return dapper().Update(jugador);
        }

        DapperJugadorController dapper()
        {
            return new DapperJugadorController();
        }
    }
}
