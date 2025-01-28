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


                Console.WriteLine("Choose a customer you would like to book:");

                var customer = context.Customers.ToList();

                foreach (var customrs in customer)
                {
                    Console.WriteLine($"{customrs.CustomerId}: {customrs.FirstName} {customrs.LastName}");
                }

                var customerID = int.Parse(Console.ReadLine());


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

                int count = 1;
                foreach (var time in bookedTimes)
                {
                    Console.WriteLine($"{count}. {time}");
                    count++;
                }

                Console.Write("Choose a time: ");
                int chosenTimeIndex = int.Parse(Console.ReadLine());
                var chosenTime = bookedTimes[chosenTimeIndex - 1];



                var newAppointment = new Appointment
                {
                    AppointmentDatetime = chosenTime,
                    EmployeeId = employeeId,
                    TreatmentId = treatmentId,
                    CustomerId = customerID
                };

                 var ap = context.Appointments.FirstOrDefault(t => t.AppointmentDatetime == chosenTime);
                 ap.AppointmentDatetime = chosenTime;
                ap.EmployeeId = employeeId;
                ap.TreatmentId = treatmentId;
                ap.CustomerId = customerID;

                context.SaveChanges();

                Console.WriteLine("Customer booking suceeded!");
            }

        }
    }
}
