using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace EFTrainingLibrary.Repos
{
    public class EFTrainerRepoAsync : IEFTrainerRepoAsync
    {
        EYTrainingsDBContext ctx = new EYTrainingsDBContext();
        public async Task DeleteTrainerAsync(int trainerId)
        {
            Trainer trainer = await GetTrainerByIdAsync(trainerId);
            ctx.Remove(trainer);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Trainer>> GetAllTrainersAsync()
        {
            List<Trainer> trainers = await ctx.Trainers.ToListAsync();
            return (trainers);
        }

        public async Task<Trainer> GetTrainerByIdAsync(int trainerId)
        {
            try
            {
                Trainer trainer = await (from t in ctx.Trainers where t.TrainerId == trainerId select t).FirstAsync();
                return trainer;
            }
            catch
            {
                throw new TrainingsException("No Trainer with this ID");
            }
        }

        public async Task<List<Trainer>> GetTrainersByTypeAsync(string trainerType)
        {
            List<Trainer> trainers = await (from tt in ctx.Trainers where tt.TrainerType == trainerType select tt).ToListAsync();
            if (trainers.Count > 0)
            {
                return trainers;
            }
            else
            {
                throw new TrainingsException("No Trainers with this TrainingType");
            }
        }

        public async Task InsertTrainerAsync(Trainer trainer)
        {
            await ctx.Trainers.AddAsync(trainer);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateTrainerAsync(Trainer trainer, int trainerId)
        {
            Trainer trainer2update = await GetTrainerByIdAsync(trainerId);
            trainer2update.TrainerId = trainerId;
            trainer2update.TrainerName = trainer.TrainerName;
            trainer2update.TrainerType = trainer.TrainerType;
            trainer2update.TrainerPhone = trainer.TrainerPhone;
            trainer2update.TrainerEmail = trainer.TrainerEmail;
            await ctx.SaveChangesAsync();
        }
    }
}
