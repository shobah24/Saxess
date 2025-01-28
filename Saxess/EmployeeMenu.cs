using Microsoft.EntityFrameworkCore;
using Saxess.Models;
using System.Runtime.ExceptionServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Saxess
{
    internal class EmployeeMenu : Menu

    {
        private static string arrow = "<--";
        private int current;
        private static string[] marker = { arrow, " ", " " };
        public override void ViewMenu()
        {
            ViewEmployees();
        }

        private void ViewEmployees()
        {
            current = 0;
            int idchoice = 0;
            bool viewingemployees = true;

            while (viewingemployees)
            {

                using (var context = new SassexDbContext())
                {
                    Console.WriteLine("All employees");
                    Console.WriteLine("---------------------------------");

                    Console.Write($"{"First name",-20}");
                    Console.Write($"{"Last name",-20}");
                    Console.Write($"{"Age",5}");
                    Console.WriteLine();

                    foreach (Employee e in context.Employees)
                    {
                        Console.Write($"{e.FirstName,-20}");
                        Console.Write($"{e.LastName,-20}");
                        Console.Write($"{e.Age,5}");
                        Console.Write($"{marker[e.EmployeeId - 1]}");
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.WriteLine("Choose an employee to see booked appointments.");
                    ConsoleKeyInfo cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.UpArrow && current > 0)
                    {
                        marker[current] = " ";
                        current--;
                        marker[current] = arrow;
                    }
                    else if (cki.Key == ConsoleKey.DownArrow && current < marker.Length - 1)
                    {
                        marker[current] = " ";
                        current++;
                        marker[current] = arrow;

                    }
                    else if (cki.Key == ConsoleKey.Enter)
                    {
                        if (current == 0)
                        {
                            idchoice = 1;
                            viewingemployees = false;
                        }
                        else if (current == 1)
                        {
                            idchoice = 2;
                            viewingemployees = false;
                        }
                        else if (current == 2)
                        {
                            idchoice = 3;
                            viewingemployees = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                        }
                    }
                    Console.Clear();
                }
            }


            foreach (Employee id in EmployeeAppointments(idchoice))
            {
                Console.Write($"{"Employee",-20}");
                Console.Write($"{"Date and time",-30} ");
                Console.Write($"{"Treatment",-20} ");
                Console.WriteLine();

                foreach (Appointment a in id.Appointments)
                {
                    Console.Write($"{id.FirstName,-20}");
                    Console.Write($"{a.AppointmentDatetime,-30}");
                    Console.Write($" {a.Treatment.TreatmentName,-20} ");
                    Console.WriteLine();
                }

            }
            Console.WriteLine("Press enter to return");
            Console.ReadLine();






        }

        private List<Employee> EmployeeAppointments(int id)
        {

            using (var context = new SassexDbContext())
            {

                var employeeBusy = context.Employees
                    .Where(i => i.EmployeeId == id)
                    .Include(ap => ap.Appointments)
                    .ThenInclude(tm => tm.Treatment)
                    .ToList();

                return employeeBusy;

            }

        }

    }
}
