using MvcWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWithAuth.ViewModel
{
    public class NewMovViewModel
    {
        public IEnumerable<Genre> Genre{ get; set; }
        public Movie Movie { get; set; }
    }
}