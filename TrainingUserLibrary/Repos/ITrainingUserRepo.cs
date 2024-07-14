using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUserLibrary.Models;
namespace TrainingUserLibrary.Repos
{
    public interface ITrainingUserRepo
    {
        Task RegisterAsync(TrainingUser user);
        Task LoginAsync(string userId, string password);
        Task<TrainingUser> GetUserDetails(string userId);
    }
}
