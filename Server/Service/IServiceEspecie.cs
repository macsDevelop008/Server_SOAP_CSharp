using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceEspecie" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceEspecie
    {
        [OperationContract]
        bool InsertEspecie(Especie especie);

        [OperationContract]
        bool UpdateEspecie(Especie especie);

        [OperationContract]
        bool DeleteEspecie(Especie especie);

        [OperationContract]
        Especie FindById(Especie especie);

        [OperationContract]
        List<Especie> List();
    }
}
