using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cinemaat_TEST.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinemaat_TEST.Controllers
{
    public class MoviesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            CinemaatContext context = HttpContext.RequestServices.GetService(typeof(Cinemaat_TEST.Models.CinemaatContext)) as CinemaatContext;

            return View(context.GetAllMovies());
        }
    }
}
