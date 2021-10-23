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
        public bool DeleteJugador(String id)
        {
            Jugador jugador = new Jugador();
            jugador.Id = id;
            return dapper().Delete(jugador);
        }

        public Jugador FindById(String id)
        {
            Jugador jugador = new Jugador();
            jugador.Id = id;
            return dapper().FindbyId(jugador);
        }

 
        public bool InsertJugador(string id, string cuenta, string pass, string apodo, string email, int estado, string fecha)
        {
            Jugador jugador = new Jugador();
            jugador.Id = id;
            jugador.Cuenta = cuenta;
            jugador.Contraseña = pass;
            jugador.Apodo = apodo;
            jugador.Email = email;
            jugador.EstadoRegistro = estado;
            jugador.FechaModificacion = fecha;

            return dapper().Insert(jugador);
        }

        public List<Jugador> List()
        {
            return dapper().List();
        }

        public bool UpdateJugador(string id, string cuenta, string pass, string apodo, string email, int estado, string fecha)
        {
            Jugador jugador = new Jugador();
            jugador.Id = id;
            jugador.Cuenta = cuenta;
            jugador.Contraseña = pass;
            jugador.Apodo = apodo;
            jugador.Email = email;
            jugador.EstadoRegistro = estado;
            jugador.FechaModificacion = fecha;
            return dapper().Update(jugador);
        }

        DapperJugadorController dapper()
        {
            return new DapperJugadorController();
        }
    }
}
