using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Server.Model
{
    [DataContract]
    public class Jugador
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Cuenta { get; set; }
        [DataMember]
        public string Contraseña { get; set; }
        [DataMember]
        public string Apodo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int EstadoRegistro { get; set; }
        [DataMember] 
        public string FechaModificacion { get; set; }
    }
}