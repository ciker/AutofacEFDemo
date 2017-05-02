using AutofacDemo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Data.Mapping
{
    public class LogMap : AutofacEntityTypeConfiguration<Logs>
    {
        public LogMap()
        {
            ToTable("Log");
            this.HasKey(t => t.Id);
        }
    }
}
