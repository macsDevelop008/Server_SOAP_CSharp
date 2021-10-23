using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Server.Model
{
    [DataContract]
    public class Especie
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int EstadoRegistro { get; set; }
        [DataMember]
        public string FechaModificacion 
        { get; set; }
    }
}