using MvcCodeFirst.Data;
using MvcCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentDbContext dbContext = new StudentDbContext();
            List<Student> studentlist = dbContext.students.OrderBy(c => c.Name).ToList();
            return View(studentlist);
            //return View();
        }
        public ActionResult Create()
        {
            var department = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="EC",
                    Value="1"
                },
                new SelectListItem
                {
                    Text="CS",
                    Value="2"
                },
                new SelectListItem
                {
                    Text="EEE",
                    Value="3"
                }
            };
            ViewBag.Department = department;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentDbContext dbContext = new StudentDbContext();
                dbContext.students.Add(student);
                dbContext.SaveChanges();
                ViewBag.Message = "Saved Successfully";
                var department = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text="EC",
                        Value="1"
                    },
                    new SelectListItem
                    {
                        Text="CS",
                        Value="2"
                    },
                    new SelectListItem
                    {
                        Text="EEE",
                        Value="3"
                    }
                };
                ViewBag.Department = department;
                //return View();
                return Json(new { message = "Saved Succesfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(student);
            }
        }
        public ActionResult Edit(int Id)
        {
            StudentDbContext dbContext = new StudentDbContext();
            Student student = dbContext.students.Where(c => c.Id == Id).FirstOrDefault();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student stud)
        {
            StudentDbContext dbContext = new StudentDbContext();
            Student student = dbContext.students.Where(c => c.Id == stud.Id).FirstOrDefault();
            //student.Name = emp.Name;
            //student.Email = emp.Email;
            //student.departmentId = emp.departmentId;
            dbContext.Entry(student).CurrentValues.SetValues(stud);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            StudentDbContext dbContext = new StudentDbContext();
            Student student = dbContext.students.Where(c => c.Id == Id).FirstOrDefault();
            return View(student);
        }
        public ActionResult Delete(int Id)
        {
            StudentDbContext dbContext = new StudentDbContext();
            Student student = dbContext.students.Where(c => c.Id == Id).FirstOrDefault();
            dbContext.students.Remove(student);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchStud()
        {
            return View();
        }
       
        public ActionResult Search(Student stud)
        {
            StudentDbContext dbContext = new StudentDbContext();
            Student student = dbContext.students.Where(c => c.Name == stud.Name & c.Email == stud.Email).FirstOrDefault();
            return PartialView("Search",student);
        }
    }
}