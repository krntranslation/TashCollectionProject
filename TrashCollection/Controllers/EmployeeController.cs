﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    [Authorize(Roles= "Employee")]
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
            return View(context.Employees.ToList());
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
                editEmployee.Id = employee.Id;
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
    }
}
