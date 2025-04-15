using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public class GenericRepository<T> where T : BaseEntity
    {
        private readonly IDataStorage<T> _storage;

        public GenericRepository(IDataStorage<T> storage)
        {
            _storage = storage;
        }

        public void Add(T entity)
        {
            _storage.Add(entity);
            _storage.Save();
        }

        public void Update(T entity)
        {
            _storage.Update(entity);
            _storage.Save();
        }

        public void Delete(int id)
        {
            _storage.Delete(id);
            _storage.Save();
        }

        public T? GetById(int id)
        {
            return _storage.GetById(id);
        }

        public List<T> GetAll()
        {
            return _storage.GetAll();
        }
    }

}
