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
    public class HRDataRepository : IHRDataRepository
    {

        private readonly ApplicationDBContext _dBContext;

        public HRDataRepository(ApplicationDBContext context)
        {
            _dBContext = context;
        }
        public async Task<HR_Data> CreateAsync(HR_Data hrdata)
        {
            var created = _dBContext.HR_Data.Add(hrdata);
            await _dBContext.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<HR_Data> GetDuplication(HR_Data hrdata)
        {
            return await _dBContext.HR_Data.FirstOrDefaultAsync(c => 
            c.Salary == hrdata.Salary &&
            c.SecurityNumber == hrdata.SecurityNumber);
                   
               
        }
    }
}
