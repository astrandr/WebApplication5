using WebApplication5.Models;

namespace WebApplication5.Services
{
    public interface IEmployeeService
    {
        Task<List<DepartmentEmployee>> GetAllAsync();
        Task<DepartmentEmployee?> GetByIdAsync(int id);
        Task<DepartmentEmployee> CreateAsync(CreateDepartmentEmployeeRequest request);
        Task<bool> UpdateAsync(int id, UpdateDepartmentEmployeeRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
