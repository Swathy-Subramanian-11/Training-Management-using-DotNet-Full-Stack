namespace TrainingMvcApp.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        public string EmpName { get; set; } = null!;

        public string Designation { get; set; } = null!;

        public string EmpPhone { get; set; } = null!;

        public string EmpEmail { get; set; } = null!;
    }
}
