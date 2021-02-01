using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginacionAPS.ViewModels
{
    public class Paginador
    {
        public int TotalItems { get; set; }
        public int PaginaActual { get; set; }
        public int CantidadPaginas { get; set; }

        public int TotalPaginas { get; set; }
        public int InicioPagina { get; set; }
        public int FinalPagina { get; set; }

        // Otro parametro (pasado como variable)
        public int? Edad { get; set; }

        public Paginador()
        { 
        }

        public Paginador(int totalItems, int pagina, int cantidadPaginas = 10)
        {
            int totalPaginas = (int)Math.Ceiling((decimal)totalItems / (decimal)cantidadPaginas);
            int paginaActual = pagina;

            //cantidad de paginas que muestra el paginador
            int inicioPagina = paginaActual - 5; 
            int finalPagina = paginaActual + 4;

            if (inicioPagina <= 0)
            {
                finalPagina = finalPagina - (inicioPagina - 1); // 6-(-3-1) = 10
                inicioPagina = 1;
            }

            if (finalPagina > totalPaginas)
            {
                finalPagina = totalPaginas;
                if (finalPagina > 10)
                {
                    inicioPagina = finalPagina - 9;
                }
            }

            TotalItems = totalItems;
            PaginaActual = paginaActual;
            CantidadPaginas = cantidadPaginas;
            TotalPaginas = totalPaginas;
            InicioPagina = inicioPagina;
            FinalPagina = finalPagina;
        }

    }

    
}
