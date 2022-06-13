using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beetee_Task.Domain.Entities;

namespace Beetee_Task.DAL.Interfaces
{
    public interface IHRDataRepository
    {
        Task<HR_Data> CreateAsync(HR_Data hrdata);

        Task<HR_Data> GetDuplication(HR_Data hrdata);
    }
}
