using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicePersonaje" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicePersonaje
    {
        [OperationContract]
        bool InsertPersonaje(Personaje personaje);

        [OperationContract]
        bool UpdatePersonaje(Personaje personaje);

        [OperationContract]
        bool DeletePersonaje(Personaje personaje);

        [OperationContract]
        Personaje FindById(Personaje personaje);

        [OperationContract]
        List<Personaje> List();
    }
}
