namespace BookApp1.Classes {
    public interface IPublisherRepository {
        void CreatePublisher(Publisher publisher);
        Publisher? GetPublisherById(int id);
        List<Publisher> GetPublishers();
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(int id); 
    }
}