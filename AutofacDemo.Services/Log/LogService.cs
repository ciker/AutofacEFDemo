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
        //private readonly IRepository<Logs> _repository;

        private  ObjectContext _context ;

        public LogService(ObjectContext context)
        {
            _context = context;

        }

        public void SaveLog(string message)
        {
            var entity = new Logs();
            entity.Message = message;
            entity.CreateDate = DateTime.Now;

            _context.LogList.Add(entity);
            _context.SaveChanges();
        }

        public List<Logs>  logList()
        {
            return _context.LogList.ToList();
        }
    }
}
