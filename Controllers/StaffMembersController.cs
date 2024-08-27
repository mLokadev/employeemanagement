//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using EmployeeManagement.Models;

//namespace EmployeeManagement.Controllers
//{
//    public class EmployeesController : Controller
//    {
//        private EmployeeContext db = new EmployeeContext();

//        // GET: /Employees/
//        public ActionResult Index()
//        {
//            return View(db.Employees.ToList());
//        }

//        // GET: /Employees/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Employee employee = db.Employees.Find(id);
//            if (employee == null)
//            {
//                return HttpNotFound();
//            }
//            return View(employee);
//        }

//        // GET: /Employees/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: /Employees/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include="EmployeeID,FirstName,LastName,Email,Position,Salary")] Employee employee)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Employees.Add(employee);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(employee);
//        }

//        // GET: /Employees/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Employee employee = db.Employees.Find(id);
//            if (employee == null)
//            {
//                return HttpNotFound();
//            }
//            return View(employee);
//        }

//        // POST: /Employees/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include="EmployeeID,FirstName,LastName,Email,Position,Salary")] Employee employee)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(employee).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(employee);
//        }

//        // GET: /Employees/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Employee employee = db.Employees.Find(id);
//            if (employee == null)
//            {
//                return HttpNotFound();
//            }
//            return View(employee);
//        }

//        // POST: /Employees/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Employee employee = db.Employees.Find(id);
//            db.Employees.Remove(employee);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}



//using System.Linq;
//using System.Web.Mvc;
//using EmployeeManagement.Models;

//namespace EmployeeManagement.Controllers
//{
//    public class StaffMembersController : Controller
//    {
//        private EmployeeContext db = new EmployeeContext();

//        // GET: StaffMembers
//        public ActionResult Index()
//        {
//            var staffMembers = db.StaffMember.ToList();
//            return View(staffMembers);
//        }

//        // GET: StaffMembers/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: StaffMembers/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(StaffMember staffMember)
//        {
//            if (ModelState.IsValid)
//            {
//                db.StaffMember.Add(staffMember);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(staffMember);
//        }
//    }
//}


//using System;
//using System.Linq;
//using System.Web.Mvc;
//using EmployeeManagement.Models;

//namespace EmployeeManagement.Controllers
//{
//    public class StaffMembersController : Controller
//    {
//        private EmployeeContext db = new EmployeeContext();

//        // GET: StaffMembers
//        public ActionResult Index()
//        {
//            var staffMembers = db.StaffMember.ToList(); // Ensure this matches your DbSet name
//            return View(staffMembers);
//        }

//        // GET: StaffMembers/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: StaffMembers/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(StaffMember staffMember)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    db.StaffMember.Add(staffMember); // Ensure this matches your DbSet name
//                    db.SaveChanges();
//                    ViewBag.Message = "Data entered successfully!";

//                    return RedirectToAction("Index");
//                }
//                catch (Exception ex)
//                {
//                    // Log the exception message
//                    ViewBag.ErrorMessage = "An error occurred while saving the data: " + ex.Message;
//                    // Optionally, log the error to a file or other logging system here
//                }
//            }

//            return View(staffMember);
//        }

//        // Optional: Dispose method to clean up the database context
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}

using System;
using System.Data.Entity;  // Required for EntityState
using System.Linq;
using System.Net;  // Required for HttpStatusCode
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class StaffMembersController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: StaffMembers
        public ActionResult Index()
        {
            var staffMembers = db.StaffMember.ToList();
            return View(staffMembers);
        }

        // GET: StaffMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffMembers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffMember staffMember)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.StaffMember.Add(staffMember);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Data entered successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while saving the data: " + ex.Message;
                }
            }

            return View(staffMember);
        }

        // GET: StaffMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffMember staffMember = db.StaffMember.Find(id);
            if (staffMember == null)
            {
                return HttpNotFound();
            }
            return View(staffMember);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffMember staffMember)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(staffMember).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Data updated successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while updating the data: " + ex.Message;
                }
            }
            return View(staffMember);
        }
        //GET: // delete

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffMember staffMember = db.StaffMember.Find(id);
            if (staffMember == null)
            {
                return HttpNotFound();
            }
            return View(staffMember);
        }

        // POST: StaffMembers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffMember staffMember = db.StaffMember.Find(id);
            if (staffMember != null)
            {
                db.StaffMember.Remove(staffMember);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Data deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error: Staff member not found.";
            }
            return RedirectToAction("Index");
        }

        // Dispose method to clean up the database context
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
