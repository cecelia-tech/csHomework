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
    }
}
