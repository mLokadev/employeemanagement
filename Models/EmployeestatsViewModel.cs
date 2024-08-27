using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class EmployeeStatsViewModel
    {
        public int TotalEmployees { get; set; }
        public decimal AverageSalary { get; set; }
        public Employee HighestPaidEmployee { get; set; }
        public Employee LowestPaidEmployee { get; set; }
        public Dictionary<string, int> PositionDistribution { get; set; }

        // For Charts
        public ChartData PositionChartData { get; set; }

        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public decimal Salary { get; set; }
        }

        public class ChartData
        {
            public List<string> Labels { get; set; }
            public List<int> Values { get; set; }
        }
    }
}
