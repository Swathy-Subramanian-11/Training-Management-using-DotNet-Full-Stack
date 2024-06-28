namespace TrainingMvcApp.Models
{
    public class Training
    {
        public int TrainingId { get; set; }

        public int TechnologyId { get; set; }

        public int TrainerId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }
    }
}
