using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUserLibrary.Models;

namespace TrainingUserLibrary.Repos
{
    public class TrainingUserRepo:ITrainingUserRepo
    {
        TrainingUserDBContext ctx = new TrainingUserDBContext();

        public async Task<TrainingUser> GetUserDetails(string userId)
        {
            try
            {
                TrainingUser user = await (from usr in ctx.TrainingUsers where usr.UserId == userId select usr).FirstAsync(); ;
                return user;
            }
            catch (Exception)
            {
                throw new TrainingUserException("No such UserId");
            }
        }

        public async Task LoginAsync(string userId, string password)
        {
            try
            {
                TrainingUser user = await (from usr in ctx.TrainingUsers where usr.UserId == userId && usr.UserPassword == password select usr).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingUserException("Ivalid UserId/Password");
            }
        }

        public async Task RegisterAsync(TrainingUser user)
        {
            try
            {
                await ctx.TrainingUsers.AddAsync(user);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingUserException(ex.Message);
            }
        }
    }
}
