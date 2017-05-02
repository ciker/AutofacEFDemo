using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacDemo.Core.Data;
using AutofacDemo.Core;
using AutofacDemo.Data;

namespace AutofacDemo.Services.Users
{
    public class UserService : IUserService
    {
        //private readonly IRepository<User> _repository;
        private ObjectContext _context;


        public UserService(ObjectContext context)
        {
            _context = context;
        }

        public void Delete(User user)
        {
            if(user==null)
            throw new NotImplementedException("User is null");
            _context.UserList.Remove(user);
            _context.SaveChanges();
            //_repository.Delete(user);
        }

        public User GetById(int id)
        {
            return _context.UserList.FirstOrDefault(t => t.Id == id);
            //return _repository.GetById(id);
        }

        public void Insert(User user)
        {
            if (user == null)
                throw new NotImplementedException("User is null");
            _context.UserList.Add(user);
            _context.SaveChanges();
            //_repository.Insert(user);
        }

        public void Update(User user)
        {
            if (user == null)
                throw new NotImplementedException("User is null");
            var users = _context.UserList.FirstOrDefault(t => t.Id == user.Id);
            users.Name = user.Name;
            users.Age = user.Age;
            user.Adress = user.Adress;
            user.Tel = user.Tel;
            _context.SaveChanges();
            //_repository.Update(user);
        }

        public List<User> UserList()
        {
            return _context.UserList.ToList();
            //return _repository.Table.ToList();
        }
    }
}
