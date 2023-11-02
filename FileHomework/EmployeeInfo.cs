using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHomework
{
    public class EmployeeInfo
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public double Bonus { get; set; }
        public string Bank { get; set; }
        public EmployeeInfo(string ename, double esalary, double ebonus, string bank)
        {
            Name = ename;
            Salary = esalary;
            Bonus = ebonus;
            Bank = bank;
        }

       

    }
}
