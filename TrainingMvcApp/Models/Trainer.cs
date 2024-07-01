using System;
using System.Collections.Generic;
namespace TrainingMvcApp.Models
{

    public partial class Trainer
    {
        public int TrainerId { get; set; }

        public string TrainerName { get; set; } = null!;

        public string TrainerType { get; set; } = null!;

        public string TrainerPhone { get; set; } = null!;

        public string TrainerEmail { get; set; } = null!;

    }
}