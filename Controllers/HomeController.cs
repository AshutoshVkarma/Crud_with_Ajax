using Crud_with_Ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_with_Ajax.Controllers
{
    public class HomeController : Controller
    {
        public AshutoshDbEntities entities;
        public HomeController()
        {
            entities = new AshutoshDbEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomers()
        {
            var customer = entities.Customers.ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PostCustomer(Customer cust)
        {
            entities.Customers.Add(cust);
            entities.SaveChanges();
            return Json(cust, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveCustomer(int id)
        {
            var c = entities.Customers.SingleOrDefault(e => e.id == id);
            entities.Customers.Remove(c);
            entities.SaveChanges();
            return Json(c, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditCustomer(int id)
        {
            var c = entities.Customers.SingleOrDefault(e => e.id == id);
            return Json(c, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer cust)
        {
            entities.Entry(cust).State = System.Data.EntityState.Modified;
            entities.SaveChanges();
            return Json(cust, JsonRequestBehavior.AllowGet);
        }
    }
}