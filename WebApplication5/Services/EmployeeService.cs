using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Logging.ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, Microsoft.Extensions.Logging.ILogger<EmployeeService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<DepartmentEmployee>> GetAllAsync()
        {
            _logger.LogInformation("Service: Get all department employees");
            return await _repository.GetAllAsync();
        }

        public async Task<DepartmentEmployee?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Service: Get department employee by id {Id}", id);
            return await _repository.GetByIdAsync(id);
        }

        public async Task<DepartmentEmployee> CreateAsync(CreateDepartmentEmployeeRequest request)
        {
            _logger.LogInformation("Service: Create department employee {Employee}", request.Employee);
            var employee = _mapper.Map<DepartmentEmployee>(request);
            var created = await _repository.AddAsync(employee);
            _logger.LogInformation("Service: Created department employee with id {Id}", created.Id);
            return created;
        }

        public async Task<bool> UpdateAsync(int id, UpdateDepartmentEmployeeRequest request)
        {
            _logger.LogInformation("Service: Update department employee id {Id}", id);
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                _logger.LogWarning("Service: Department employee id {Id} not found for update", id);
                return false;
            }

            _mapper.Map(request, employee);

            await _repository.UpdateAsync(employee);
            _logger.LogInformation("Service: Updated department employee id {Id}", id);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Service: Delete department employee id {Id}", id);
            var isExists = await _repository.ExistsAsync(id);
            if (!isExists)
            {
                _logger.LogWarning("Service: Department employee id {Id} not found for delete", id);
                return false;
            }

            await _repository.DeleteAsync(id);
            _logger.LogInformation("Service: Deleted department employee id {Id}", id);
            return true;
        }
    }
}
