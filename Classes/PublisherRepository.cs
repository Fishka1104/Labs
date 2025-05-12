using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {

    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(IDataStorage<Publisher> storage) : base(storage)
        {
        }

        public List<Publisher> GetPublishers()
        {
            return base.GetAll();
        }

        public void CreatePublisher(Publisher publisher)
        {
            base.Add(publisher);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            base.Update(publisher);
        }

        public void DeletePublisher(int publisherId)
        {
            base.Delete(publisherId);
        }

        public Publisher? GetPublisherById(int publisherId)
        {
            return base.GetById(publisherId);
        }
    }
}