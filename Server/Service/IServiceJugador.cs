using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceJugador" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceJugador
    {
        [OperationContract]
        bool InsertJugador(Jugador jugador);

        [OperationContract]
        bool UpdateJugador(Jugador jugador);

        [OperationContract]
        bool DeleteJugador(Jugador jugador);

        [OperationContract]
        Jugador FindById(Jugador jugador);

        [OperationContract]
        List<Jugador> List();

    }
}
