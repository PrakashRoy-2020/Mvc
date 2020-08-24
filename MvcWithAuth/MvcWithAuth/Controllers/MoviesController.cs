using MvcWithAuth.Models;
using MvcWithAuth.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWithAuth.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult IndexMov()
        {
            var movies = _context.Movies.Include(c=>c.Genre).ToList();
            return View(movies);
        }
        public ActionResult DetailsMov(int id)
        {
            var singleMovie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (singleMovie == null)
                return HttpNotFound();
            return View(singleMovie);
        }
        public ActionResult NewMov()
        {
            var genres = _context.Genres.ToList();
            var viewModelMov = new NewMovViewModel
            {
                Genre = genres
            };
            return View(viewModelMov);
        }
        [HttpPost]
        //model binding
        //name should always be create for httppost
        public ActionResult Create(Movie movie)//NewCustViewModel vm
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            //no need to add view
            return RedirectToAction("IndexMov", "Movies");
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
    
}