using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace BookApp1.Classes
{

    public class JsonStorage<T> : IDataStorage<T> where T : BaseEntity
    {
        private readonly string _filePath;
        private List<T> _items;

        public JsonStorage(string filePath)
        {
            _filePath = filePath;
            _items = LoadFromFile();
        }

        private List<T> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<T>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public void Add(T entity)
        {
            entity.Id = _items.Any() ? _items.Max(e => e.Id) + 1 : 1;
            _items.Add(entity);
        }

        public void Update(T entity)
        {
            var index = _items.FindIndex(e => e.Id == entity.Id);
            if (index != -1)
            {
                _items[index] = entity;
            }
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(e => e.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public T? GetById(int id)
        {
            return _items.FirstOrDefault(e => e.Id == id);
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(_items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }


    }

}
