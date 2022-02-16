using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyVacations
{
    public class CompanyVacationInfo
    {
        private List<EmployeeVacations> allVacationsRecords = new List<EmployeeVacations>();

        public void AddEmployeeVacations(EmployeeVacations x)
        {
            if (x is null)
            {
                throw new ArgumentNullException();
            }

            if (AlreadyOnVacation(x))
            {
                throw new ArgumentException("Employee is already on vacation");
            }

            allVacationsRecords.Add(x);
        }

        public bool AlreadyOnVacation(EmployeeVacations a)
        {
            var r = allVacationsRecords.Where(x => x.Name.Equals(a.Name))
                                       .Where(x => a.vacationsStart <= x.vacationsEnd &&
                                                    a.vacationsEnd >= x.vacationsStart)
                                       .Count();

            return r == 0 ? false : true;
        }

        public double AverageVacationLength()
        {
            return allVacationsRecords.Distinct()
                                      .Select(x => x.VacationsTaken.TotalDays)
                                      .Average();
        }

        public IEnumerable<(string, double)> GetAverageOfEachEmployee()
        {
            return allVacationsRecords.Distinct().GroupBy(x => x.Name)
                                      .Select(x => (x.Key, x.Select(c => c.VacationsTaken.TotalDays).Average()))
                                      .ToList();
        }

        public IEnumerable<(int, int)> EmployeesPerMonth()
        {
            Dictionary<int, int> a = new Dictionary<int, int>();

            var start = allVacationsRecords.Select(x => x.vacationsStart);

            var end = allVacationsRecords.Where(x => x.vacationsStart.Month != x.vacationsEnd.Month)
                                         .Select(x => x.vacationsEnd);

            start.Concat(end).GroupBy(x => x.Month)
                             .Select(x => (x.Key, x.Count())).ToList().
                             ForEach(x => a.Add(x.Key, x.Item2));

            foreach (var month in Enumerable.Range(1, 12))
            {
                if (a.ContainsKey(month))
                {
                    continue;
                }
                else
                {
                    a.Add(month, 0);
                }
            }
            return a.OrderBy(x => x.Key).Select(x => (x.Key, x.Value));
        }


    }

}
