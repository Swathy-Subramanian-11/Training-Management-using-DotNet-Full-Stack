using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTrainingLibrary.Models;

namespace EFTrainingLibrary.Repos
{
    internal interface IEFTrainingRepoAsync
    {
        Task<List<Training>> GetAllTrainingsAsync();
        Task<Training> GetTrainingByIdAsync(int trainingId);

        Task<List<Training>> GetTrainingByTechnologyIdAsync(int techId);
        Task<List<Training>> GetTrainingByTrainerIdAsync(int trainerId);


        Task InsertTraining(Training training);
        Task UpdateTrainingAsync(int trainingId, Training training);
        Task DeleteTrainingAsync(int trainingId);
    }
}
