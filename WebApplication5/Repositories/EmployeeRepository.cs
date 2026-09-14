using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly Microsoft.Extensions.Logging.ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(AppDbContext dbContext, Microsoft.Extensions.Logging.ILogger<EmployeeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<DepartmentEmployee>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all department employees");
            return await _dbContext.DepartmentEmployees.AsNoTracking().ToListAsync();
        }

        public async Task<DepartmentEmployee?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Retrieving department employee with id {Id}", id);
            return await _dbContext.DepartmentEmployees.FindAsync(id);
        }

        public async Task<DepartmentEmployee> AddAsync(DepartmentEmployee employee)
        {
            _logger.LogInformation("Adding new department employee: {Employee}", employee.Employee);
            _dbContext.DepartmentEmployees.Add(employee);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("Added department employee with id {Id}", employee.Id);
            return employee;
        }

        public async Task UpdateAsync(DepartmentEmployee employee)
        {
            _logger.LogInformation("Updating department employee with id {Id}", employee.Id);

            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("Updated department employee with id {Id}", employee.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting department employee with id {Id}", id);
            var employee = await _dbContext.DepartmentEmployees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.DepartmentEmployees.Remove(employee);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Deleted department employee with id {Id}", id);
                return true;
            }
            else
            {
                _logger.LogWarning("Attempted to delete non-existing department employee with id {Id}", id);
                return false;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var exists = await _dbContext.DepartmentEmployees.AnyAsync(e => e.Id == id);
            _logger.LogInformation("Exists check for department employee id {Id}: {Exists}", id, exists);
            return exists;
        }
    }
}
