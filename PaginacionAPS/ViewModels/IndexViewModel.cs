using PaginacionAPS.Models;
using System.Collections.Generic;

namespace PaginacionAPS.ViewModels
{
    public class IndexViewModel : BaseModelo
    {
        public List<Persona> Personas { get; set; }
    }
}
