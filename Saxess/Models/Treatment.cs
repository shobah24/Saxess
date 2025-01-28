using System;
using System.Collections.Generic;

namespace Saxess.Models;

public partial class Treatment
{
    public int TreatmentId { get; set; }

    public string? TreatmentName { get; set; }

    public string? TreatmentType { get; set; }
    public decimal? Price { get; set; }


    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
