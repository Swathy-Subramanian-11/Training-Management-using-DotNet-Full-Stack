using EFTrainingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public interface IEFTechnologyRepoAsync 
    {
        
        Task<List<Technology>> GetAllTechnologyAsync();
        Task<List<Technology>> GetTechnologyByType(string type);
        Task <Technology> GetTechnologyAsync(int techId);
        Task  AddTechnologyAsync(Technology tech);
        Task  UpdateTechnologyAsync(int techId ,Technology tech);
        Task  DeleteTechnologyAsync(int techId);

    }
}
