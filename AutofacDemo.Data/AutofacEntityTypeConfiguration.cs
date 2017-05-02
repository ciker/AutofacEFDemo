using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Data
{
    public class AutofacEntityTypeConfiguration<T> :EntityTypeConfiguration<T> where T:class
    {
        protected AutofacEntityTypeConfiguration()
        {
            PostInitialize();
        }
        protected virtual void PostInitialize()
        {

        }
    }
}
