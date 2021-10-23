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
        bool InsertJugador(String id,String cuenta, String pass, String apodo,String email,int estado,String fecha);

        [OperationContract]
        bool UpdateJugador(String id, String cuenta, String pass, String apodo, String email, int estado, String fecha);

        [OperationContract]
        bool DeleteJugador(String id);

        [OperationContract]
        Jugador FindById(String id);

        [OperationContract]
        List<Jugador> List();

    }
}
