using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Services.Log
{
    public interface ILogService
    {
        void  SaveLog(string message);
    }
}
