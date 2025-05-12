using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {
    public class SQLiteStorage<T> : IDataStorage<T> where T : BaseEntity {
        private readonly string _connectionString = "Data Source=library.db;Version=3;";
        private readonly string _tableName;

        public SQLiteStorage(string tableName) {
            _tableName = tableName;
            InitializeDatabase();
        }

        private void InitializeDatabase() {
            var createTablesQueries = new Dictionary<Type, string>
            {
                { typeof(User), "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT NOT NULL, HashedPassword TEXT NOT NULL, Role TEXT NOT NULL)" },
                { typeof(Author), "CREATE TABLE IF NOT EXISTS Authors (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, BirthDate TEXT, DeathDate TEXT, Nationality TEXT, Genres TEXT)" },
                { typeof(Publisher), "CREATE TABLE IF NOT EXISTS Publishers (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Headquarters TEXT, Address TEXT, Founded TEXT, CeoFounder TEXT)" },
                { typeof(Book), "CREATE TABLE IF NOT EXISTS Books (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT NOT NULL, Isbn TEXT NOT NULL, AuthorId INTEGER NOT NULL, PublisherId INTEGER NOT NULL, Category TEXT NOT NULL, FOREIGN KEY (AuthorId) REFERENCES Authors(Id), FOREIGN KEY (PublisherId) REFERENCES Publishers(Id))" },
                { typeof(BorrowedBook), "CREATE TABLE IF NOT EXISTS BorrowedBooks (Id INTEGER PRIMARY KEY AUTOINCREMENT, UserId INTEGER NOT NULL, BookId INTEGER NOT NULL, Title TEXT NOT NULL, Isbn TEXT, Author TEXT, Publisher TEXT, Category TEXT, AuthorId INTEGER, PublisherId INTEGER, FOREIGN KEY (UserId) REFERENCES Users(Id), FOREIGN KEY (BookId) REFERENCES Books(Id))" }
            };

            try {
                using (var connection = new SQLiteConnection(_connectionString)) {
                    connection.Open();
                    foreach (var query in createTablesQueries.Values) {
                        using (var command = new SQLiteCommand(query, connection)) {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            } catch (SQLiteException ex) {
                Console.WriteLine($"SQLite error in InitializeDatabase: {ex.Message}");
                throw; // Re-throw to catch issues early
            }
        }

        public void Add(T entity) {
            try {
                using (var connection = new SQLiteConnection(_connectionString)) {
                    connection.Open();
                    string query = GetInsertQuery(entity);
                    Console.WriteLine($"Executing query: {query}");
                    using (var command = new SQLiteCommand(query, connection)) {
                        AddParameters(command, entity);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {rowsAffected}");
                        if (rowsAffected > 0) {
                            entity.Id = (int)connection.LastInsertRowId;
                            Console.WriteLine($"Assigned ID: {entity.Id}");
                        } else {
                            Console.WriteLine("Failed to insert entity.");
                            throw new SQLiteException("No rows affected during insert.");
                        }
                    }
                }
            } catch (SQLiteException ex) {
                Console.WriteLine($"SQLite error in Add: {ex.Message}");
                throw; // Re-throw to propagate error
            } catch (Exception ex) {
                Console.WriteLine($"General error in Add: {ex.Message}");
                throw;
            }
        }

        public void Update(T entity) {
            try {
                using (var connection = new SQLiteConnection(_connectionString)) {
                    connection.Open();
                    string query = GetUpdateQuery(entity);
                    Console.WriteLine($"Executing query: {query}");
                    using (var command = new SQLiteCommand(query, connection)) {
                        AddParameters(command, entity);
                        command.Parameters.AddWithValue("@Id", entity.Id);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {rowsAffected}");
                        if (rowsAffected == 0) {
                            Console.WriteLine($"No rows updated for entity ID: {entity.Id}");
                            throw new SQLiteException($"No rows updated for entity ID: {entity.Id}");
                        }
                    }
                }
            } catch (SQLiteException ex) {
                Console.WriteLine($"SQLite error in Update: {ex.Message}");
                throw; // Re-throw to propagate error
            } catch (Exception ex) {
                Console.WriteLine($"General error in Update: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id) {
            try {
                using (var connection = new SQLiteConnection(_connectionString)) {
                    connection.Open();
                    string query = $"DELETE FROM {_tableName} WHERE Id = @Id";
                    Console.WriteLine($"Executing query: {query}");
                    using (var command = new SQLiteCommand(query, connection)) {
                        command.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {rowsAffected}");
                    }
                }
            } catch (SQLiteException ex) {
                Console.WriteLine($"SQLite error in Delete: {ex.Message}");
                throw;
            }
        }

        public T? GetById(int id) {
            try {
                using (var connection = new SQLiteConnection(_connectionString)) {
                    connection.Open();
                    string query = $"SELECT * FROM {_tableName} WHERE Id = @Id";
                    Console.WriteLine($"Executing query: {query}");
                    using (var command = new SQLiteCommand(query, connection)) {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                return MapToEntity(reader);
                            }
                        }
                    }
                }
            } catch (SQLiteException ex) {
                Console.WriteLine($"SQLite error in GetById: {ex.Message}");
                throw;
            }
            return null;
        }

        public List<T> GetAll() {
            var items = new List<T>();
            try {
                using (var connection = new SQLiteConnection(_connectionString)) {
                    connection.Open();
                    string query = $"SELECT * FROM {_tableName}";
                    Console.WriteLine($"Executing query: {query}");
                    using (var command = new SQLiteCommand(query, connection)) {
                        using (var reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                items.Add(MapToEntity(reader));
                            }
                        }
                    }
                }
            } catch (SQLiteException ex) {
                Console.WriteLine($"SQLite error in GetAll: {ex.Message}");
                throw;
            }
            return items;
        }

        public void Save() {
            // No-op, as changes are committed immediately
        }

        private string GetInsertQuery(T entity) {
            return entity switch {
                User => "INSERT INTO Users (Username, HashedPassword, Role) VALUES (@Username, @HashedPassword, @Role)",
                Author => "INSERT INTO Authors (Name, BirthDate, DeathDate, Nationality, Genres) VALUES (@Name, @BirthDate, @DeathDate, @Nationality, @Genres)",
                Publisher => "INSERT INTO Publishers (Name, Headquarters, Address, Founded, CeoFounder) VALUES (@Name, @Headquarters, @Address, @Founded, @CeoFounder)",
                Book => "INSERT INTO Books (Title, Isbn, AuthorId, PublisherId, Category) VALUES (@Title, @Isbn, @AuthorId, @PublisherId, @Category)",
                BorrowedBook => "INSERT INTO BorrowedBooks (UserId, BookId, Title, Isbn, Author, Publisher, Category, AuthorId, PublisherId) VALUES (@UserId, @BookId, @Title, @Isbn, @Author, @Publisher, @Category, @AuthorId, @PublisherId)",
                _ => throw new NotSupportedException($"Type {typeof(T)} is not supported.")
            };
        }

        private string GetUpdateQuery(T entity) {
            return entity switch {
                User => "UPDATE Users SET Username = @Username, HashedPassword = @HashedPassword, Role = @Role WHERE Id = @Id",
                Author => "UPDATE Authors SET Name = @Name, BirthDate = @BirthDate, DeathDate = @DeathDate, Nationality = @Nationality, Genres = @Genres WHERE Id = @Id",
                Publisher => "UPDATE Publishers SET Name = @Name, Headquarters = @Headquarters, Address = @Address, Founded = @Founded, CeoFounder = @CeoFounder WHERE Id = @Id",
                Book => "UPDATE Books SET Title = @Title, Isbn = @Isbn, AuthorId = @AuthorId, PublisherId = @PublisherId, Category = @Category WHERE Id = @Id",
                BorrowedBook => "UPDATE BorrowedBooks SET UserId = @UserId, BookId = @BookId, Title = @Title, Isbn = @Isbn, Author = @Author, Publisher = @Publisher, Category = @Category, AuthorId = @AuthorId, PublisherId = @PublisherId WHERE Id = @Id",
                _ => throw new NotSupportedException($"Type {typeof(T)} is not supported.")
            };
        }

        private void AddParameters(SQLiteCommand command, T entity) {
            switch (entity) {
                case User user:
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@HashedPassword", user.HashedPassword);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    break;
                case Author author:
                    command.Parameters.AddWithValue("@Name", author.Name);
                    command.Parameters.AddWithValue("@BirthDate", author.BirthDate?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DeathDate", author.DeathDate?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Nationality", author.Nationality ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Genres", JsonSerializer.Serialize(author.Genres) ?? (object)DBNull.Value);
                    break;
                case Publisher publisher:
                    command.Parameters.AddWithValue("@Name", publisher.Name);
                    command.Parameters.AddWithValue("@Headquarters", publisher.Headquarters ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Address", publisher.Address ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Founded", publisher.Founded?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CeoFounder", publisher.CeoFounder ?? (object)DBNull.Value);
                    break;
                case Book book:
                    command.Parameters.AddWithValue("@Title", book.Title ?? "Unknown");
                    command.Parameters.AddWithValue("@Isbn", book.Isbn?.Code ?? "Unknown");
                    command.Parameters.AddWithValue("@AuthorId", book.AuthorId);
                    command.Parameters.AddWithValue("@PublisherId", book.PublisherId);
                    command.Parameters.AddWithValue("@Category", book.Category?.Name ?? "Unknown");
                    break;
                case BorrowedBook borrowedBook:
                    command.Parameters.AddWithValue("@UserId", borrowedBook.UserId);
                    command.Parameters.AddWithValue("@BookId", borrowedBook.BookId);
                    command.Parameters.AddWithValue("@Title", borrowedBook.Title);
                    command.Parameters.AddWithValue("@Isbn", borrowedBook.Isbn ?? "Unknown");
                    command.Parameters.AddWithValue("@Author", borrowedBook.Author ?? "Unknown");
                    command.Parameters.AddWithValue("@Publisher", borrowedBook.Publisher ?? "Unknown");
                    command.Parameters.AddWithValue("@Category", borrowedBook.Category ?? "Unknown");
                    command.Parameters.AddWithValue("@AuthorId", borrowedBook.AuthorId);
                    command.Parameters.AddWithValue("@PublisherId", borrowedBook.PublisherId);
                    break;
                default:
                    throw new NotSupportedException($"Type {typeof(T)} is not supported.");
            }
        }

        private T MapToEntity(SQLiteDataReader reader) {
            if (typeof(T) == typeof(User)) {
                var user = new User {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    HashedPassword = reader.GetString(reader.GetOrdinal("HashedPassword")),
                    Role = reader.GetString(reader.GetOrdinal("Role"))
                };
                Console.WriteLine($"Mapped user: {user.Username}, HashedPassword: {user.HashedPassword}");
                return (T)(object)user;
            } else if (typeof(T) == typeof(Author)) {
                return (T)(object)new Author {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) ? null : DateTime.Parse(reader.GetString(reader.GetOrdinal("BirthDate"))),
                    DeathDate = reader.IsDBNull(reader.GetOrdinal("DeathDate")) ? null : DateTime.Parse(reader.GetString(reader.GetOrdinal("DeathDate"))),
                    Nationality = reader.IsDBNull(reader.GetOrdinal("Nationality")) ? null : reader.GetString(reader.GetOrdinal("Nationality")),
                    Genres = reader.IsDBNull(reader.GetOrdinal("Genres")) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(reader.GetString(reader.GetOrdinal("Genres")))
                };
            } else if (typeof(T) == typeof(Publisher)) {
                return (T)(object)new Publisher {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Headquarters = reader.IsDBNull(reader.GetOrdinal("Headquarters")) ? null : reader.GetString(reader.GetOrdinal("Headquarters")),
                    Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                    Founded = reader.IsDBNull(reader.GetOrdinal("Founded")) ? null : DateTime.Parse(reader.GetString(reader.GetOrdinal("Founded"))),
                    CeoFounder = reader.IsDBNull(reader.GetOrdinal("CeoFounder")) ? null : reader.GetString(reader.GetOrdinal("CeoFounder"))
                };
            } else if (typeof(T) == typeof(Book)) {
                return (T)(object)new Book {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    Isbn = new Isbn { Code = reader.GetString(reader.GetOrdinal("Isbn")) },
                    AuthorId = reader.GetInt32(reader.GetOrdinal("AuthorId")),
                    PublisherId = reader.GetInt32(reader.GetOrdinal("PublisherId")),
                    Category = new Category { Name = reader.GetString(reader.GetOrdinal("Category")) }
                };
            } else if (typeof(T) == typeof(BorrowedBook)) {
                return (T)(object)new BorrowedBook {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                    BookId = reader.GetInt32(reader.GetOrdinal("BookId")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    Isbn = reader.IsDBNull(reader.GetOrdinal("Isbn")) ? null : reader.GetString(reader.GetOrdinal("Isbn")),
                    Author = reader.IsDBNull(reader.GetOrdinal("Author")) ? null : reader.GetString(reader.GetOrdinal("Author")),
                    Publisher = reader.IsDBNull(reader.GetOrdinal("Publisher")) ? null : reader.GetString(reader.GetOrdinal("Publisher")),
                    Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString(reader.GetOrdinal("Category")),
                    AuthorId = reader.GetInt32(reader.GetOrdinal("AuthorId")),
                    PublisherId = reader.GetInt32(reader.GetOrdinal("PublisherId"))
                };
            }
            throw new NotSupportedException($"Type {typeof(T)} is not supported.");
        }
    }
}