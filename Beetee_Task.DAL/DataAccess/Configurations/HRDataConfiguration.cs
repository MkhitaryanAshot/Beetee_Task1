using Beetee_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beetee_Task.DAL.DataAccess.Configurations
{
    public class HRDataConfiguration : IEntityTypeConfiguration<HR_Data>
    {

        public void Configure(EntityTypeBuilder<HR_Data> builder)
        {
            builder.HasOne(c => c.Employee).WithOne(c => c.HR_Data);
        }
    }
}
