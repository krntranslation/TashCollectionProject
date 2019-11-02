using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        ApplicationDbContext context;

        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        [Authorize(Roles = "Employee")]
        public ActionResult Index()
        {
            var customerList = context.Customers.ToList();
            return View(customerList);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var detailCustomer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(detailCustomer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                string id = User.Identity.GetUserId();
                customer.ApplicationId = id;
                context.Customers.Add(customer);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var editCustomer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(editCustomer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                var editCustomer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
                editCustomer.Id = customer.Id;
                editCustomer.FirstName = customer.FirstName;
                editCustomer.LastName = customer.LastName;
                editCustomer.StreetAddress = customer.StreetAddress;
                editCustomer.City = customer.City;
                editCustomer.StateCode = customer.StateCode;
                editCustomer.Zipcode = customer.Zipcode;
                editCustomer.PickUpDate = customer.PickUpDate;
                editCustomer.StartDate = customer.StartDate;
                editCustomer.EndDate = customer.EndDate;
                editCustomer.PickUpDayOfTheWeek = customer.PickUpDayOfTheWeek;
             
                editCustomer.PickupConfirmed = customer.PickupConfirmed;
                editCustomer.Balance = customer.Balance;
            
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteCustomer = context.Customers.Where(d => d.Id == id).FirstOrDefault();
            return View(deleteCustomer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                var deletedCustomer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
                context.Customers.Remove(deletedCustomer);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //Trying to add Emegency Pick Up
        public ActionResult AddPickUp(int id)
        {
            var addEmergencyPickUp = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(addEmergencyPickUp);
        }
        [HttpPost]
        public ActionResult AddPickUp(int id, Customer customer)
        {
            try
            {
                var addEmergencyPickUpDate = context.Customers.Where(x => x.Id == id).FirstOrDefault();
                addEmergencyPickUpDate.PickUpDate = customer.PickUpDate;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //Trying to add Change pick up dates
        public ActionResult ChangePickUpDates(int id)
        {
            var changePickUp = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(changePickUp);
        }
        [HttpPost]
        public ActionResult ChangePickUpDates(int id, Customer customer)
        {
            try
            {
                var changePickUpDate = context.Customers.Where(x => x.Id == id).FirstOrDefault();
                changePickUpDate.StartDate = customer.StartDate;
                changePickUpDate.EndDate = customer.EndDate;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //Changing pick up date
        public ActionResult ChangePickUpForDayOfTheWeek(int id)
        {
            var changePickUpDay = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(changePickUpDay);
        }
        [HttpPost]
        public ActionResult ChangePickUpForDayOfTheWeek(int id, Customer customer)
        {
            try
            {
                var changePickUpDay = context.Customers.Where(x => x.Id == id).FirstOrDefault();
                changePickUpDay.PickUpDayOfTheWeek = customer.PickUpDayOfTheWeek;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ViewBalance(int id)
        {
            var viewBalance = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(viewBalance);
        }

        [HttpPost]
        public ActionResult ViewBalance(int id, Customer customer)
        {
            try
            {
                var changeCost = context.Customers.Where(x => x.Id == id).FirstOrDefault();
                changeCost.Balance = customer.Balance;
                changeCost.PickupConfirmed = customer.PickupConfirmed;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //below here the three Action results are trying to have only employee have access to charging and changing values
        [Authorize(Roles ="Employee")]
        public ActionResult ConfirmPickUp(int id)
        {
            var editCustomer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(editCustomer);
        }
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult ConfirmPickUp(int id, Customer customer)
        {
            try
            {
                var editCustomer = context.Customers.Where(x => x.Id == id).FirstOrDefault();

                editCustomer.PickupConfirmed = customer.PickupConfirmed;
                editCustomer.Balance = customer.Balance;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
