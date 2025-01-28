using Saxess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saxess
{
    internal class AddnewBooking
    {
        public void AddBooking()
        {
            using (var context = new SassexDbContext())
            {
                Console.WriteLine("Choose an employee you would like a treatment from:");

                var employees = context.Employees.ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.EmployeeId}: {employee.FirstName} {employee.LastName}");
                }

                var employeeId = int.Parse(Console.ReadLine());

                Console.WriteLine("Choose a treatment you would like to get:");
                var treatments = context.Treatments.ToList();
                foreach (var treatment in treatments)
                {
                    Console.WriteLine($"{treatment.TreatmentId}: {treatment.TreatmentName} ({treatment.Price} kr)");
                }

                var treatmentId = int.Parse(Console.ReadLine());

                Console.WriteLine("Our available times:");
                var bookedTimes = context.Appointments
                    .Where(a => a.CustomerId == null && a.EmployeeId == null && a.TreatmentId == null)
                    .Select(a => a.AppointmentDatetime)
                    .ToList();

                foreach (var time in bookedTimes)
                {
                    Console.WriteLine($"{time}");
                }

                Console.Write("Choose a time (ex:2024-01-28 12:00): ");
                var chosenTime = DateTime.Parse(Console.ReadLine());

               
                var newAppointment = new Appointment
                {
                    AppointmentDatetime = chosenTime,
                    EmployeeId = employeeId,
                    TreatmentId = treatmentId
                };

                context.Appointments.Add(newAppointment);
                context.SaveChanges();

                Console.WriteLine("Customer booking suceeded!");
            }

        }
    }
}
