using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<DepartmentEmployee>> GetAllAsync();
        Task<DepartmentEmployee?> GetByIdAsync(int id);
        Task<DepartmentEmployee> AddAsync(DepartmentEmployee employee);
        Task UpdateAsync(DepartmentEmployee employee);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
