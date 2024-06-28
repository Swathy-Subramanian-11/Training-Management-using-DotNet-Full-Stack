using System;
using System.Collections.Generic;

namespace EFTrainingLibrary.Models;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string TrainerName { get; set; } = null!;

    public string TrainerType { get; set; } = null!;

    public string TrainerPhone { get; set; } = null!;

    public string TrainerEmail { get; set; } = null!;

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
