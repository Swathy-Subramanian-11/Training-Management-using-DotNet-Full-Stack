using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTrainingLibrary.Models;

namespace EFTrainingLibrary.Repos
{
    public  interface IETraineeRepoAsync
    {
        Task<List<Trainee>> GetAllTraineesAsync();
        Task<List<Trainee>> GetTraineeByEmpIdAsync(int EmpId);
        Task<List<Trainee>> GetTraineeByTrainingIdAsync(int TrainingId);

        Task<Trainee> GetTraineeAsync(int EmpId, int TrainingId);

        Task InsertTraineeAsync(Trainee tra);
        Task UpdateTraineeAsync(int EmpId, Trainee tra, int TrainingId);
        Task DeleteTraineeAsync(int EmpId, int TrainingId);

    }
}
