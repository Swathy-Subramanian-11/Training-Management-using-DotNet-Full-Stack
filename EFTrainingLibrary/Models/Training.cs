using System;
using System.Collections.Generic;

namespace EFTrainingLibrary.Models;

public partial class Training
{
    public int TrainingId { get; set; }

    public int TechnologyId { get; set; }

    public int TrainerId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual Technology? Technology { get; set; } = null!;

    public virtual ICollection<Trainee>? Trainees { get; set; } = new List<Trainee>();

    public virtual Trainer? Trainer { get; set; } = null!;
}
