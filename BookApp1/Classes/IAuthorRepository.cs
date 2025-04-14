namespace BookApp1.Classes {
    public interface IAuthorRepository {
        void CreateAuthor(Author author);
        Author? GetAuthorById(int id);
        List<Author> GetAuthors();
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id); 
    }
}