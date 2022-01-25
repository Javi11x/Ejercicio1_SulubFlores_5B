using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peli.Domain.entities
{
    public class Pelicula
    {
        public int idPeli { get; set; }
        public string tituloPeli { get; set; }
        public string directorPeli { get; set; }
        public string generoPeli { get; set; }
        public int puntuacionPeli { get; set; }
        public int ratingPeli { get; set; }
        public int añopPeli { get; set; }
    }
}