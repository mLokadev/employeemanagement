using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: /Employees/
        public ActionResult Index()
        {
            var employees = db.StaffMember.ToList();
            return View(employees);
        }

        // GET: /Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffMember employee)
        {
            if (ModelState.IsValid)
            {
                db.StaffMember.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: /Employees/DownloadImage
        public ActionResult DownloadImage()
        {
            var employees = db.StaffMember.ToList();

            // Define the image size
            int width = 800;
            int rowHeight = 30;
            int headerHeight = 50;
            int totalRows = employees.Count;
            int height = headerHeight + (rowHeight * totalRows) + 40; // Extra padding

            using (Bitmap bitmap = new Bitmap(width, height))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (MemoryStream ms = new MemoryStream())
            {
                graphics.Clear(Color.White);
                Font font = new Font("Arial", 12);
                Brush brush = Brushes.Black;
                Pen pen = new Pen(Color.Black);

                // Draw header
                graphics.DrawString("Employee Report", new Font("Arial", 16, FontStyle.Bold), brush, new PointF(10, 10));

                // Draw table headers
                graphics.DrawRectangle(pen, 10, headerHeight, width - 20, rowHeight);
                graphics.DrawString("First Name", font, brush, new PointF(15, headerHeight + 5));
                graphics.DrawString("Last Name", font, brush, new PointF(150, headerHeight + 5));
                graphics.DrawString("Email", font, brush, new PointF(280, headerHeight + 5));
                graphics.DrawString("Position", font, brush, new PointF(420, headerHeight + 5));
                graphics.DrawString("Salary", font, brush, new PointF(580, headerHeight + 5));

                // Draw employee data
                int y = headerHeight + rowHeight;
                foreach (var employee in employees)
                {
                    graphics.DrawRectangle(pen, 10, y, width - 20, rowHeight);
                    graphics.DrawString(employee.FirstName, font, brush, new PointF(15, y + 5));
                    graphics.DrawString(employee.LastName, font, brush, new PointF(150, y + 5));
                    graphics.DrawString(employee.Email, font, brush, new PointF(280, y + 5));
                    graphics.DrawString(employee.Position, font, brush, new PointF(420, y + 5));
                    graphics.DrawString(employee.Salary.ToString("C"), font, brush, new PointF(580, y + 5));
                    y += rowHeight;
                }

                // Save to memory stream
                bitmap.Save(ms, ImageFormat.Png);

                // Return as a file result
                ms.Position = 0;
                return File(ms.ToArray(), "image/png", "EmployeeReport.png");
            }
        }

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
