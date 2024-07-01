using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EFTrainingLibrary.Repos
{
    public class EFTraineeRepoAsync : IETraineeRepoAsync
    {
        EYTrainingsDBContext ctx = new EYTrainingsDBContext();

        public async Task DeleteTraineeAsync(int EmpId, int TrainingId)
        {
            Trainee flight = await GetTraineeAsync(EmpId,TrainingId);
            ctx.Trainees.Remove(flight);
            ctx.SaveChangesAsync();
        }

        public async Task<List<Trainee>> GetAllTraineesAsync()
        {
            List<Trainee> tras = await ctx.Trainees.ToListAsync();

            return (tras);

        }
       
        public async Task<Trainee> GetTraineeAsync(int Id, int TId)
        {
            try
            {
                Trainee fs = await (from s in ctx.Trainees where s.EmpId == Id && s.TrainingId == TId select s).FirstAsync();
                return fs;
            }
            catch
            {
                throw new Exception("No such schedule");
            }


        }

        public async Task<List<Trainee>> GetTraineeByEmpIdAsync(int EId)
        {
            List<Trainee> trainees = await(from s in ctx.Trainees where s.EmpId == EId select s).ToListAsync();
            if (trainees.Count > 0)
            {
                return trainees;
            }
            else
            {
                throw new Exception("No Trainee Found");
            }
        }

        public async Task<List<Trainee>> GetTraineeByTrainingIdAsync(int TId)
        {
            List<Trainee> trainees = await(from s in ctx.Trainees where s.TrainingId == TId select s).ToListAsync();
            if (trainees.Count > 0)
            {
                return trainees;
            }
            else
            {
                throw new Exception("No Trainee Found");
            }
        }

        public async Task InsertTraineeAsync(Trainee tra)
        {
            await ctx.Trainees.AddAsync(tra);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateTraineeAsync(int EmpId, Trainee tra, int TrainingId)
        {
            Trainee tra2update = await GetTraineeAsync(EmpId, TrainingId);
            tra2update.EmpId = EmpId;
            tra2update.TrainingId = tra.TrainingId;
            tra2update.Status = tra.Status;
            await ctx.SaveChangesAsync();
        }

       
    }
}
