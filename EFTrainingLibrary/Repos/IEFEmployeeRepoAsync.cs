using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTrainingLibrary.Models;
namespace EFTrainingLibrary.Repos
{
    public interface IEFEmployeeRepoAsync
    {
        Task <List<Employee>> GetEmployeesAsync();
        Task <Employee> GetEmployeeByIdAsync(int empId);

        Task<List<Employee>> GetEmployeeByDesignationAsync(string desg);

        Task InsertEmployeeAsync(Employee emp);  
        Task UpdateEmployeeAsync(int empId ,Employee employee);
        Task DeleteEmployeeAsync (int empId);
    }
}
