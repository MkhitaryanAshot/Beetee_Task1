using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beetee_Task.DAL.Interfaces;
using Beetee_Task.Domain.Entities;
using Beetee_Task.DAL.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Beetee_Task.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly IApplicationDbContext _dbContext;
        private readonly IHRDataRepository _hRDataRepository;

        public EmployeeRepository(IApplicationDbContext dBContext, IHRDataRepository hRData)
        {
            _dbContext = dBContext;
            _hRDataRepository = hRData;
        }
        public async Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken)
        {
            if (employee.Id == Guid.Empty)
            {
                employee.Id = Guid.NewGuid();
            }

            var createdEmployee = await _dbContext.Employees.AddAsync(employee, cancellationToken);

            await _dbContext.SaveChangesAsync();

            return createdEmployee.Entity;
        }

        public async Task<Employee> UpdateAsync(Employee emp, CancellationToken cancellationToken)
        {

            var employee = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == emp.Id, cancellationToken);
            var updatedEmployee = _dbContext.Employees.Update(emp);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return updatedEmployee.Entity;
        }

        public IQueryable<Employee> Get()
        {
            return _dbContext.Employees.Where(x => x.State == State.Active).AsQueryable();
        }

        public async Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Employees.Include(x => x.HR_Data).FirstOrDefaultAsync(x => x.Id == id && x.State == State.Active, cancellationToken);
        }

        public async Task HardDeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);


            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }



        public async Task SoftDeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = _dbContext.Employees.FirstOrDefault(x => x.Id == id);

            result.State = State.Inactive;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Employee> Get_SoftDeleted()
        {
            return _dbContext.Employees.Where(x => x.State == State.Inactive).AsQueryable();
        }
    }
}
