using AutoMapper;
using AutoMapper.QueryableExtensions;
using Beetee_Task.DAL.Interfaces;
using Beetee_Task.Domain.Entities;
using Beetee_Task.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beetee_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeRepository _employeerepo;
        private readonly IMapper _mapper;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeRepository employeerepository,
            IMapper mapper)
        {
            _logger = logger;
            _employeerepo = employeerepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDataDTO>> Get(CancellationToken cancellationToken)
        {
            var result = _employeerepo.Get().Include(x => x.HR_Data);

            return await result.ProjectTo<EmployeeDataDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDataDTO> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _employeerepo.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<EmployeeDataDTO>(result);
        }

        [HttpGet("Removed")]
        public async Task<IEnumerable<EmployeeDataDTO>> Get_SoftDeleted(CancellationToken cancellationToken)
        {
            var result = _employeerepo.Get_SoftDeleted().Include(x => x.HR_Data);

            return await result.ProjectTo<EmployeeDataDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }


        [HttpPost]
        public async Task<EmployeeDataDTO> Create(EmployeeDataDTO employeeDataDTO, CancellationToken cancellationToken)
        {
            var result = await _employeerepo.CreateAsync(
                _mapper.Map<Employee>(employeeDataDTO), cancellationToken);

            return _mapper.Map<EmployeeDataDTO>(result);
        }


        [HttpPut]
        public async Task<EmployeeDataDTO> Update(EmployeeDataDTO employeeDataDTO, CancellationToken cancellationToken)
        {
            var result = await _employeerepo.UpdateAsync(
                _mapper.Map<Employee>(employeeDataDTO), cancellationToken);

            return _mapper.Map<EmployeeDataDTO>(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(Guid id, CancellationToken cancellationToken)
        {
            await _employeerepo.HardDeleteAsync(id, cancellationToken);

            return Ok(200);
        }


        [HttpDelete("Soft")]
        public async Task<IActionResult> SoftDelete(Guid id, CancellationToken cancellationToken)
        {
            await _employeerepo.SoftDeleteAsync(id, cancellationToken);

            return Ok(200);
        }

    }
}

