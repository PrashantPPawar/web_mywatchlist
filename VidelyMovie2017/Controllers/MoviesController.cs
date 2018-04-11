using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidelyMovie2017.Models;
using VidelyMovie2017.ViewModels;

namespace VidelyMovie2017.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var Movie = new Movie() { Name = "Jannat!" };

            var Customers = new List<Customer>
            {

                new Customer{ Name="Customer 1"},
                new Customer { Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = Movie,
                Customers=Customers
            };

           // return View(Movie);
            return View(viewModel);
        }
    }
}