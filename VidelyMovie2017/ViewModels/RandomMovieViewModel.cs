using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidelyMovie2017.Models;

namespace VidelyMovie2017.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }


    }
}