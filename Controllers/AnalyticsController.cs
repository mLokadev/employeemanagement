using EmployeeManagement.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    public class AnalyticsController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Analytics/EmployeeStats
        public ActionResult EmployeeStats()
        {
            // Calculate position distribution
            var positionDistribution = db.StaffMember
                .GroupBy(e => e.Position)
                .Select(g => new
                {
                    Position = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(g => g.Position, g => g.Count);

            var stats = new EmployeeStatsViewModel
            {
                TotalEmployees = db.StaffMember.Count(),
                AverageSalary = db.StaffMember.Average(e => e.Salary),
                HighestPaidEmployee = db.StaffMember
                    .OrderByDescending(e => e.Salary)
                    .Select(e => new EmployeeStatsViewModel.Employee
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Salary = e.Salary
                    })
                    .FirstOrDefault(),
                LowestPaidEmployee = db.StaffMember
                    .OrderBy(e => e.Salary)
                    .Select(e => new EmployeeStatsViewModel.Employee
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Salary = e.Salary
                    })
                    .FirstOrDefault(),
                PositionDistribution = positionDistribution,
                PositionChartData = new EmployeeStatsViewModel.ChartData
                {
                    Labels = positionDistribution.Keys.ToList(),
                    Values = positionDistribution.Values.ToList()
                }
            };

            return View(stats);
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
