using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib.Repository
{
    public class BankRepository<T>:IBankRepository<T> where T: class
    {
        private BankDBContext _context;
        private DbSet<T> table;

        public BankRepository()
        {
            _context = new BankDBContext();
            table = _context.Set<T>();
        }

        public bool AddUser(T obj)
        {
            try
            {
                table.Add(obj);
                Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<T> GetAllUsers()
        {
            return table.ToList();
        }

        public T GetUserByName(string userName)
        {
            return table.Find(userName);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdateUser(T obj)
        {
            try
            {
                table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
                Save();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
