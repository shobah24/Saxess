using System;
using System.Collections.Generic;

namespace Saxess.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
