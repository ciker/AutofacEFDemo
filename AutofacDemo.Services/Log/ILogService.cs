using AutofacDemo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Services.Log
{
    public interface ILogService:IDependency
    {
        void  SaveLog(string message);

        List<Logs> logList();
    }
}
