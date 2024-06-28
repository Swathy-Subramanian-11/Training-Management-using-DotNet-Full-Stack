using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTrainingLibrary.Repos
{
    public class EFTrainingRepoAsync : IEFTrainingRepoAsync
    {
        EYTrainingsDBContext ctx = new EYTrainingsDBContext();

        public async Task DeleteTrainingAsync(int trainingId)
        {
            Training training=await GetTrainingByIdAsync(trainingId);
            ctx.Remove(training);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Training>> GetAllTrainingsAsync()
        {
            List<Training> tranings=await ctx.Training.ToListAsync();
            return tranings;
        }

        public async Task<Training> GetTrainingByIdAsync(int trainingId)
        {
            try
            {
                Training training = await (from t in ctx.Training where t.TrainingId == trainingId select t).FirstAsync();
                return training;
            }
            catch
            {
                throw new TrainingsException("No Training found with this ID");
            }
        }

        public async Task<List<Training>> GetTrainingByTechnologyIdAsync(int techId)
        {
            List<Training> trnByTech= await (from t in ctx.Training where t.TechnologyId == techId select t).ToListAsync();
            if(trnByTech.Count > 0)
            {
                return trnByTech;
            }
            else
            {
                throw new TrainingsException("No trainings with this Technology");
            }
        }

        public async Task<List<Training>> GetTrainingByTrainerIdAsync(int trainerId)
        {
            List<Training> trnByTrainer = await (from t in ctx.Training where t.TrainerId == trainerId select t).ToListAsync();
            if (trnByTrainer.Count > 0)
            {
                return trnByTrainer;
            }
            else
            {
                throw new TrainingsException("No trainings with this Trainer");
            }
        }

        public async Task InsertTrainingAsync(Training training)
        {
            await ctx.Training.AddAsync(training);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateTrainingAsync(int trainingId, Training training)
        {
            Training trn2update = await GetTrainingByIdAsync(trainingId);
            //trn2update.TrainingId = trainingId;
            trn2update.TechnologyId = training.TechnologyId;
            trn2update.TrainerId = training.TrainerId;
            trn2update.StartDate = training.StartDate;
            trn2update.EndDate = training.EndDate;
            await ctx.SaveChangesAsync();
        }
    }
}
