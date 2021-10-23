using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Server.Model
{
    [DataContract]
    public class Personaje
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public double Fuerza { get; set; }
        [DataMember]
        public double Mana { get; set; }
        [DataMember]
        public double Energia { get; set; }
        [DataMember]
        public string IdEspecie { get; set; }
        [DataMember]
        public string IdJugador { get; set; }
        [DataMember]
        public int EstadoRegistro { get; set; }
        [DataMember]
        public string FechaModificacion { get; set; }
    }
}