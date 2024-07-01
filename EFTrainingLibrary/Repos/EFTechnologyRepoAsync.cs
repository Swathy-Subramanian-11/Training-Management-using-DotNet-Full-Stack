using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTrainingLibrary.Repos
{
    public class EFTechnologyRepoAsync : IEFTechnologyRepoAsync
    {
        EYTrainingsDBContext ctx= new EYTrainingsDBContext();
        public async Task AddTechnologyAsync(Technology tech)
        {
           await ctx.AddAsync(tech); 
           await  ctx.SaveChangesAsync(); 
        }

        public async Task DeleteTechnologyAsync(int techId)
        {
            Technology tech =await GetTechnologyAsync(techId);
            ctx.Technologies.Remove(tech);  
            await ctx.SaveChangesAsync();   
        }

        public async Task<List<Technology>> GetAllTechnologyAsync()
        {
            List<Technology> techs = await ctx.Technologies.ToListAsync();
            return techs;
        }

        public async Task<Technology> GetTechnologyAsync(int techId)
        {
            try
            {
                Technology tech = await (from t in ctx.Technologies where t.TechnologyId == techId select t).FirstAsync();
                return tech;
            }
            catch
            {
                throw new Exception("No Technology with this ID");
            }
        }

        public async Task<List<Technology>> GetTechnologyByType(string type)
        {
            List<Technology> techs = await (from t in ctx.Technologies where t.TechnologyType == type select t).ToListAsync();
            if (techs.Count > 0)
            {
                return techs;
            }
            else
            {
                throw new Exception("No Technology for this Type");
            }
        }

        public async Task UpdateTechnologyAsync(int techId, Technology tech)
        {
            Technology tech2edit = await GetTechnologyAsync(techId);
            tech2edit.TechnologyName = tech.TechnologyName;
            tech2edit.TechnologyType = tech.TechnologyType;
            await ctx.SaveChangesAsync();
        }
    }
}
