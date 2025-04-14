using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {

    public class PublisherRepository : IPublisherRepository
    {
        private readonly IDataStorage<Publisher> _storage;

        public PublisherRepository(IDataStorage<Publisher> storage)
        {
            _storage = storage;
        }

        public List<Publisher> GetPublishers()
        {
            return _storage.GetAll();
        }

        public void CreatePublisher(Publisher publisher)
        {
            _storage.Add(publisher);
            _storage.Save();
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _storage.Update(publisher);
            _storage.Save();
        }

        public void DeletePublisher(int publisherId)
        {
            _storage.Delete(publisherId);
            _storage.Save();
        }

        public Publisher? GetPublisherById(int publisherId)
        {
            return _storage.GetById(publisherId);
        }
    }
}