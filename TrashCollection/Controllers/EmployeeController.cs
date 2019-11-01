using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;

        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Employee
        public ActionResult Index()
        {
            var getEmployees = context.Employees.ToList();
            return View(getEmployees);
        }
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var detailEmployee = context.Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(detailEmployee);
        }
        // GET: Customer/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }
        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                string id = User.Identity.GetUserId();
                employee.ApplicationId = id;
                context.Employees.Add(employee);
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
            var editEmployee = context.Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(editEmployee);
        }
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                var editEmployee = context.Employees.Where(x => x.Id == id).FirstOrDefault();
                editEmployee.ZipCode = employee.ZipCode;

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
            var deleteEmployee = context.Employees.Where(d => d.Id == id).FirstOrDefault();
            return View(deleteEmployee);
        }
        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                var deletedEmployee = context.Employees.Where(x => x.Id == id).FirstOrDefault();
                context.Employees.Remove(deletedEmployee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //Dont change anything above this
        //Trying to employee user stories
       
        public ActionResult CustomerIndex()
        {
            var customerList = context.Customers.ToList();
            return View(customerList);
        }
        public ActionResult TodaysWorkLoad()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = context.Employees.Where(x => x.ApplicationId == employeeId).FirstOrDefault();
            var searchResults = context.Customers.Where(c => c.Zipcode == employee.ZipCode);
            return View(searchResults);
        }

        //public ActionResult ConfirmPickUp(int id)
        //{
        //    var editCustomer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
        //    return View(editCustomer);
        //}
        //[HttpPost]
        //public ActionResult ConfirmPickUp(int id, Customer customer)
        //{
        //    try
        //    {
        //        var editCustomer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
        //        editCustomer.PickupConfirmed = customer.PickupConfirmed;
        //        editCustomer.Balance = customer.Balance;
        //        context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();

        //    }
    
    }

}