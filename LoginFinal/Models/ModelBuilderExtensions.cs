using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginFinal.Models
{
    public  static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Mary",
                    Department = Dept.IT,
                    Email = "mary@gmail.com"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Alice",
                    Department = Dept.HR,
                    Email = "Alice98@gmail.com"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Lydia",
                    Department = Dept.Payroll,
                    Email = "Lydia@gmail.com"
                }
            );
        }
    }
}
