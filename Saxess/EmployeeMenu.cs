using Microsoft.EntityFrameworkCore;
using Saxess.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Saxess
{
    internal class EmployeeMenu : Menu

    {
        public override void ViewMenu()
        {
            ViewEmployees();
        }

        private void ViewEmployees()
        {

            using (var context = new SassexDbContext())
            {

                Console.Write($"{"First name",-20}");
                Console.Write($"{"Last name", -20} ");
                Console.Write($"{"Age", 5} ");
                Console.WriteLine();



                var employeeBusy = context.Employees
                    .Include(booked => booked.Appointments)
                    .ToList();

                foreach (Employee e in context.Employees)
                {
                    Console.Write($"{e.FirstName, -20}");
                    Console.Write($"{e.LastName, -20}");
                    Console.Write($"{e.Age, 5}");
                    Console.WriteLine();
                }

                foreach (Employee e in employeeBusy)
                {
                    Console.WriteLine(e.FirstName + e.LastName + ":");
                    foreach (Appointment a in e.Appointments)
                    {
                        Console.Write(a.AppointmentId + " ");
                        Console.Write(a.AppointmentDatetime);
                        Console.WriteLine();
                    }
                }
                    Console.WriteLine();
                
            }
        }


    }
}
