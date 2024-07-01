using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTrainingLibrary.Models;

namespace EFTrainingLibrary.Repos
{
    public interface IEFTrainerRepoAsync
    {
        Task InsertTrainerAsync(Trainer trainer);

        Task UpdateTrainerAsync(Trainer trainer,int trainerId);
        Task DeleteTrainerAsync(int trainerId);
        Task<List<Trainer>> GetAllTrainersAsync();
        Task<Trainer> GetTrainerByIdAsync(int trainerId);

        Task<List<Trainer>> GetTrainersByTypeAsync(string trainerType);

    }
}
