using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDAL.Models;

namespace BookStoreDAL.Contracts
{
    internal interface IUserRepository
    {
        public User? GetUser(string userName);
        public void AddUser(User user);
        public bool IsExist(User user);
    }
}
