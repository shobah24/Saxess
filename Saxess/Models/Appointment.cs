using System;
using System.Collections.Generic;

namespace Saxess.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? EmployeeId { get; set; }

    public int? CustomerId { get; set; }

    public int? TreatmentId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Treatment? Treatment { get; set; }
}
