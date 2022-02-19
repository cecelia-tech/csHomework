using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyVacations
{
    public class EmployeeVacations
    {
        public string Name { get; set; }
        public TimeSpan VacationsTaken { get; set; }
        public DateTime VacationsStart { get; set; }
        public DateTime VacationsEnd { get; set; }

        public EmployeeVacations(string name, DateTime firstVacationDay, DateTime lastVacationDay)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name entry is not valid");
            }
            else
            {
                Name = name;
            }

            if ((firstVacationDay.Year != 2021 && lastVacationDay.Year != 2021) ||
                firstVacationDay >= lastVacationDay)
            {
                throw new ArgumentException("Dates are not correct");
            }
            else
            {
                VacationsStart = firstVacationDay;
                VacationsEnd = lastVacationDay;

                VacationsTaken = lastVacationDay.Subtract(firstVacationDay);
            }
        }
    }
}
