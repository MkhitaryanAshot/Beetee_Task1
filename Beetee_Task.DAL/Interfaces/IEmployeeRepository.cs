using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beetee_Task.Domain.Entities;

namespace Beetee_Task.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee emp, CancellationToken cancellationToken);
        IQueryable<Employee> Get();
        IQueryable<Employee> Get_SoftDeleted();


        Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<Employee> UpdateAsync(Employee emp, CancellationToken cancellationToken);
        Task HardDeleteAsync(Guid id, CancellationToken cancellationToken);


        Task SoftDeleteAsync(Guid id,CancellationToken cancellationToken);

    }
}
