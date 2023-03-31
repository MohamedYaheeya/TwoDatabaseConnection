using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwoDatabaseConnection.Models
{
    public class EmployeModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int Emp_id { get; set; }
    }
    public class HrModel
    {
        public int Department_Id { get; set; }
        public string Department { get; set; }
        public string Manager { get; set; }
        public decimal Salary { get; set; }
    }
    public class FinalModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Manager { get; set; }
        public decimal Salary { get; set; }
    }
}