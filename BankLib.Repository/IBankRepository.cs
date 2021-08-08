using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib.Repository
{
    public interface IBankRepository<T> where T : class
    {
        bool AddUser(T obj);
        List<T> GetAllUsers();
        bool UpdateUser(T obj);
        void Save();
        T GetUserByName(string userName);
    }
}
