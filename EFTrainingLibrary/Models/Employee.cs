using System;
using System.Collections.Generic;

namespace EFTrainingLibrary.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string EmpPhone { get; set; } = null!;

    public string EmpEmail { get; set; } = null!;

    public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
}
