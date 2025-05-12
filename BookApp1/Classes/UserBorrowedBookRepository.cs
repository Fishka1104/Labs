using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

namespace BookApp1.Classes {
    public class UserBorrowedBookRepository {
        private readonly IDataStorage<User> _userStorage;
        private readonly IBookRepository _bookRepository;
        private readonly string _connectionString = "Data Source=library.db;Version=3;";

        public UserBorrowedBookRepository(IDataStorage<User> userStorage, IBookRepository bookRepository) {
            _userStorage = userStorage;
            _bookRepository = bookRepository;
        }

        public void BorrowBook(string username, Book book) {
            var user = _userStorage.GetAll().FirstOrDefault(u => u.Username == username);
            if (user == null) {
                Console.WriteLine($"Error: User {username} not found");
                return;
            }

            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();
                string query = @"
                    INSERT INTO BorrowedBooks (UserId, BookId, Title, Isbn, Author, Publisher, Category, AuthorId, PublisherId)
                    VALUES (@UserId, @BookId, @Title, @Isbn, @Author, @Publisher, @Category, @AuthorId, @PublisherId)";
                using (var command = new SQLiteCommand(query, connection)) {
                    command.Parameters.AddWithValue("@UserId", user.Id);
                    command.Parameters.AddWithValue("@BookId", book.Id);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Isbn", book.Isbn?.Code ?? "Unknown");
                    command.Parameters.AddWithValue("@Author", book.Author?.Name ?? "Unknown");
                    command.Parameters.AddWithValue("@Publisher", book.Publisher?.Name ?? "Unknown");
                    command.Parameters.AddWithValue("@Category", book.Category?.Name ?? "Unknown");
                    command.Parameters.AddWithValue("@AuthorId", book.AuthorId);
                    command.Parameters.AddWithValue("@PublisherId", book.PublisherId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ReturnBook(string username, int bookId) {
            var user = _userStorage.GetAll().FirstOrDefault(u => u.Username == username);
            if (user == null) {
                Console.WriteLine($"Error: User {username} not found");
                return;
            }

            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();
                string selectQuery = "SELECT * FROM BorrowedBooks WHERE UserId = @UserId AND BookId = @BookId";
                BorrowedBook borrowedBook = null;
                using (var selectCommand = new SQLiteCommand(selectQuery, connection)) {
                    selectCommand.Parameters.AddWithValue("@UserId", user.Id);
                    selectCommand.Parameters.AddWithValue("@BookId", bookId);
                    using (var reader = selectCommand.ExecuteReader()) {
                        if (reader.Read()) {
                            borrowedBook = new BorrowedBook {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                BookId = reader.GetInt32(reader.GetOrdinal("BookId")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Isbn = reader.IsDBNull(reader.GetOrdinal("Isbn")) ? "Unknown" : reader.GetString(reader.GetOrdinal("Isbn")),
                                Author = reader.IsDBNull(reader.GetOrdinal("Author")) ? "Unknown" : reader.GetString(reader.GetOrdinal("Author")),
                                Publisher = reader.IsDBNull(reader.GetOrdinal("Publisher")) ? "Unknown" : reader.GetString(reader.GetOrdinal("Publisher")),
                                Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? "Unknown" : reader.GetString(reader.GetOrdinal("Category")),
                                AuthorId = reader.IsDBNull(reader.GetOrdinal("AuthorId")) ? 0 : reader.GetInt32(reader.GetOrdinal("AuthorId")),
                                PublisherId = reader.IsDBNull(reader.GetOrdinal("PublisherId")) ? 0 : reader.GetInt32(reader.GetOrdinal("PublisherId"))
                            };
                        }
                    }
                }

                if (borrowedBook == null) {
                    Console.WriteLine($"Error: No borrowed book found for UserId {user.Id} and BookId {bookId}");
                    return;
                }

                try {
                    // Delete from BorrowedBooks
                    string deleteQuery = "DELETE FROM BorrowedBooks WHERE UserId = @UserId AND BookId = @BookId";
                    using (var deleteCommand = new SQLiteCommand(deleteQuery, connection)) {
                        deleteCommand.Parameters.AddWithValue("@UserId", user.Id);
                        deleteCommand.Parameters.AddWithValue("@BookId", bookId);
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Ensure valid AuthorId and PublisherId
                    if (borrowedBook.AuthorId == 0) {
                        Console.WriteLine($"Warning: AuthorId is 0 for BookId {bookId}, setting to default");
                        borrowedBook.AuthorId = GetDefaultAuthorId(connection);
                    }
                    if (borrowedBook.PublisherId == 0) {
                        Console.WriteLine($"Warning: PublisherId is 0 for BookId {bookId}, setting to default");
                        borrowedBook.PublisherId = GetDefaultPublisherId(connection);
                    }

                    // Restore to Books
                    Console.WriteLine($"Returning book {borrowedBook.BookId} for user {username}");
                    _bookRepository.ReturnBook(borrowedBook);
                } catch (Exception ex) {
                    Console.WriteLine($"Error in ReturnBook: {ex.Message}");
                    throw;
                }
            }
        }

        private int GetDefaultAuthorId(SQLiteConnection connection) {
            string selectQuery = "SELECT Id FROM Authors WHERE Name = 'Unknown'";
            using (var command = new SQLiteCommand(selectQuery, connection)) {
                var result = command.ExecuteScalar();
                if (result != null) {
                    return Convert.ToInt32(result);
                }
            }

            string insertQuery = "INSERT INTO Authors (Name, BirthDate, Nationality) VALUES ('Unknown', '1900-01-01', 'Unknown'); SELECT last_insert_rowid();";
            using (var command = new SQLiteCommand(insertQuery, connection)) {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private int GetDefaultPublisherId(SQLiteConnection connection) {
            string selectQuery = "SELECT Id FROM Publishers WHERE Name = 'Unknown'";
            using (var command = new SQLiteCommand(selectQuery, connection)) {
                var result = command.ExecuteScalar();
                if (result != null) {
                    return Convert.ToInt32(result);
                }
            }

            string insertQuery = "INSERT INTO Publishers (Name, Headquarters) VALUES ('Unknown', 'Unknown'); SELECT last_insert_rowid();";
            using (var command = new SQLiteCommand(insertQuery, connection)) {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public List<BorrowedBook> GetBorrowedBooks(string username) {
            var user = _userStorage.GetAll().FirstOrDefault(u => u.Username == username);
            if (user == null) return new List<BorrowedBook>();

            var borrowedBooks = new List<BorrowedBook>();
            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();
                string query = "SELECT * FROM BorrowedBooks WHERE UserId = @UserId";
                using (var command = new SQLiteCommand(query, connection)) {
                    command.Parameters.AddWithValue("@UserId", user.Id);
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            borrowedBooks.Add(new BorrowedBook {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                BookId = reader.GetInt32(reader.GetOrdinal("BookId")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Isbn = reader.IsDBNull(reader.GetOrdinal("Isbn")) ? "Unknown" : reader.GetString(reader.GetOrdinal("Isbn")),
                                Author = reader.IsDBNull(reader.GetOrdinal("Author")) ? "Unknown" : reader.GetString(reader.GetOrdinal("Author")),
                                Publisher = reader.IsDBNull(reader.GetOrdinal("Publisher")) ? "Unknown" : reader.GetString(reader.GetOrdinal("Publisher")),
                                Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? "Unknown" : reader.GetString(reader.GetOrdinal("Category")),
                                AuthorId = reader.IsDBNull(reader.GetOrdinal("AuthorId")) ? 0 : reader.GetInt32(reader.GetOrdinal("AuthorId")),
                                PublisherId = reader.IsDBNull(reader.GetOrdinal("PublisherId")) ? 0 : reader.GetInt32(reader.GetOrdinal("PublisherId"))
                            });
                        }
                    }
                }
            }
            return borrowedBooks;
        }
    }
}