using AutofacDemo.Core;
using AutofacDemo.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Services.Users
{
    public interface IUserService :IDependency
    {
         List<User> UserList();

        void Insert(User user);

        void Update(User user);

        void Delete(User user);

        User GetById(int id);
    }
}
