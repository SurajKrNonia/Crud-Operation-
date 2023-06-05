using CrudOperation.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        db_testEntities dbObj= new db_testEntities();
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(tbl_student model)
        {
            if (ModelState.IsValid) {
                tbl_student obj = new tbl_student();

                obj.Name = model.Name;

                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                dbObj.tbl_student.Add(obj);
                dbObj.SaveChanges();
                    }
            ModelState.Clear();
            return View("Student");
        }
        public ActionResult StudentList()
        {
            var res=dbObj.tbl_student.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)

        {
            var res=dbObj.tbl_student.Where(x=>x.ID ==id).First();
            dbObj.tbl_student.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.tbl_student.ToList();

            return View("StudentList",list);


        }
    }
}