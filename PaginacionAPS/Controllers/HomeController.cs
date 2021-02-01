using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaginacionAPS.Data;
using PaginacionAPS.Models;
using PaginacionAPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PaginacionAPS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? edad, int pagina = 1)
        {
            if (pagina < 1)
            {
                pagina = 1;
            }

            var cantidadRegistrosPorPagina = 10; // parámetro
            Func<Persona, bool> predicado = x => !edad.HasValue || edad.Value == x.Edad;
            var personas = _context.Personas.Where(predicado).OrderBy(x => x.Id)
                .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                .Take(cantidadRegistrosPorPagina).ToList();

            int totalDeRegistros;
            if (edad != null)
            {
                totalDeRegistros = _context.Personas.Where(x => x.Edad == edad).Count();
                this.ViewBag.Edad = edad;
            }
            else
            {
                totalDeRegistros = _context.Personas.Count();
            }
            


            var paginador = new Paginador(totalDeRegistros, pagina, cantidadRegistrosPorPagina);

            this.ViewBag.Paginador = paginador;
            return View(personas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
