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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MemberShipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var singleCustomer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (singleCustomer == null)
                return HttpNotFound();
            return View(singleCustomer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new NewCustViewModel
            {
                MemberShipTypes = membershipTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        //model binding
        //name should always be create for httppost
        public ActionResult Create(Customer customer)//NewCustViewModel vm
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            //no need to add view
            return RedirectToAction("Index", "Customers");
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}