using AutofacDemo.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Data.Mapping
{
    public class UserMap : AutofacEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            this.HasKey(t=>t.Id);
            this.Property(t => t.Name).IsRequired().HasMaxLength(50);
            this.Property(t => t.Tel).HasMaxLength(20);

        }
    }
}
