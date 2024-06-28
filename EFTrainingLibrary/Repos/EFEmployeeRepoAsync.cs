using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public class EFEmployeeRepoAsync : IEFEmployeeRepoAsync
    {
        EYTrainingsDBContext ctx = new EYTrainingsDBContext();
        public async  Task DeleteEmployeeAsync(int empId)
        {
            Employee emp= await GetEmployeeByIdAsync(empId);
             ctx.Remove(emp);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeeByDesignationAsync(string desg)
        {
            
                List<Employee> emps = await (from emp in ctx.Employees where emp.Designation == desg select emp).ToListAsync();
            if (emps.Count > 0)
            {
                return emps;
            }
            else
            {
                throw new TrainingsException("No Employees with this Designation");
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int empId)
        {
            try
            {
                Employee emp = await (from e in ctx.Employees where e.EmpId == empId select e).FirstAsync();
                return emp;
            }
            catch
            {
                throw new TrainingsException("No Employee with this ID");
            }
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> emps = await ctx.Employees.ToListAsync();
            return (emps);
        }

        public async Task InsertEmployeeAsync(Employee emp)
        {
          await ctx.Employees.AddAsync(emp);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(int empId, Employee employee)
        {
           Employee emp2update= await GetEmployeeByIdAsync (empId);
            emp2update.EmpId = empId;
            emp2update.EmpName = employee.EmpName;
            emp2update.Designation= employee.Designation;
            emp2update.EmpPhone = employee.EmpPhone;
            emp2update.EmpEmail = employee.EmpEmail;    
            await ctx.SaveChangesAsync();
        }
    }
}
