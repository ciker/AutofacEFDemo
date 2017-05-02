using AutofacDemo.Core;
using AutofacDemo.Core.Domain;
using AutofacDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Services.Log
{
    public class LogService : ILogService
    {
       private readonly IRepository<Logs> _repository;


        public LogService(IRepository<Logs> repository)
        {
            _repository = repository;

        }

        public void SaveLog(string message)
        {
            var entity = new Logs();
            entity.Message = message;
            entity.CreateDate = DateTime.Now;
            _repository.Insert(entity);
        }

        public List<Logs>  logList()
        {
            return _repository.Table.ToList();
        }
    }
}
