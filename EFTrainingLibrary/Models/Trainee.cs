using System;
using System.Collections.Generic;

namespace EFTrainingLibrary.Models;

public partial class Trainee
{
    public int TrainingId { get; set; }

    public int EmpId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Employee? Emp { get; set; } = null!;

    public virtual Training? Training { get; set; } = null!;
}
