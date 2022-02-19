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

        //method returns first int as a month, second int as a number of employees
        public IEnumerable<(int, int)> EmployeesPerMonth()
        {
            var vacationStartMonths = allVacationsRecords.Select(x => x.VacationsStart.Month);

            var vacationsEndMonths = allVacationsRecords.Where(x => x.VacationsStart.Month != x.VacationsEnd.Month)
                                         .Select(x => x.VacationsEnd.Month);

            return vacationStartMonths.Concat(vacationsEndMonths).GroupBy(x => x)
                                    .Select(x => (x.Key, x.Count()))
                                    .OrderBy(x => x.Key);
        }



        public IEnumerable<(DateTime, DateTime)> DatesWithNoVacations()
        {
            DateTime end = new DateTime(2021, 12, 31);
            DateTime start = new DateTime(2021, 01, 01);
            DateTime until = end;

            List<(DateTime, DateTime)> unavailabeDates = new List<(DateTime, DateTime)>();
            List<(DateTime, DateTime)> availabeDates = new List<(DateTime, DateTime)>();

            var orderedList = allVacationsRecords.OrderBy(x => x.vacationsStart.Month)
                                                 .ThenBy(x => x.vacationsStart.Day)
                                                 .Select(x => (x.vacationsStart, x.vacationsEnd));

            foreach (var entry in orderedList)
            {
                int count = unavailabeDates.Count() - 1;

                if (unavailabeDates.Count() == 0)
                {
                    unavailabeDates.Add((entry.vacationsStart, entry.vacationsEnd));
                }
                else
                {
                    if (entry.vacationsStart <= unavailabeDates[count].Item2 && entry.vacationsEnd > unavailabeDates[count].Item2)
                    {
                        unavailabeDates[count] = (unavailabeDates[count].Item1, entry.vacationsEnd);
                    }
                    else if (entry.vacationsStart > unavailabeDates[count].Item2)
                    {
                        unavailabeDates.Add((entry.vacationsStart, entry.vacationsEnd));
                    }
                }
            }

            foreach (var item in unavailabeDates)
            {
                if (start == item.Item1)
                {
                    start = item.Item2.AddDays(1);
                }
                else
                {
                    until = item.Item1.AddDays(-1);
                }
                if (until != end)
                {
                    availabeDates.Add((start, until));
                    start = item.Item2.AddDays(1);
                    until = end;
                }
                if (item.Equals(unavailabeDates[unavailabeDates.Count() - 1]))
                {
                    availabeDates.Add((start, until));
                }
            }
            return availabeDates.OrderBy(x => x.Item1).ThenBy(x => x.Item2);
        }
    }

}
