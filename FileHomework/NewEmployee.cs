using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileHomework
{
    public class NewEmployee
    {
        public string NewName { get; set; }
        public double NewSalary { get; set; }
        public double NewBonus { get; set; }
        public string NewBank { get; set; }

        public NewEmployee(string newname, double newsalary, double newbonus, string newbank) 
        {
            NewName = newname;
            NewSalary = newsalary;
            NewBonus = newbonus;
            NewBank = newbank;
        }

    }
}
