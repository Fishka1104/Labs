using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {
    public class PublisherRepository : IPublisherRepository {
        private static readonly string filePath = "publishers.json";

        private static List<Publisher> LoadPublishers() {
            if (!File.Exists(filePath)) return new List<Publisher>();
            string json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                WriteIndented = true
            };

            return JsonSerializer.Deserialize<List<Publisher>>(json, options) ?? new List<Publisher>();
        }

        private static void SavePublishers(List<Publisher> publishers) {
            string json = JsonSerializer.Serialize(publishers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<Publisher> GetPublishers() {
            return LoadPublishers();
        }

        public void CreatePublisher(Publisher publisher) {
            var publishers = LoadPublishers();
            publisher.Id = publishers.Count > 0 ? publishers[^1].Id + 1 : 1;
            publishers.Add(publisher);
            SavePublishers(publishers);
        }

        public void UpdatePublisher(Publisher publisher) {
            var publishers = LoadPublishers();
            var index = publishers.FindIndex(p => p.Id == publisher.Id);
            if (index != -1) {
                publishers[index] = publisher;
                SavePublishers(publishers);
            }
        }

        public void DeletePublisher(int publisherId) {
            var publishers = LoadPublishers();
            publishers.RemoveAll(p => p.Id == publisherId);
            SavePublishers(publishers);
        }

        public Publisher? GetPublisherById(int publisherId) {
            return LoadPublishers().FirstOrDefault(p => p.Id == publisherId);
        }
    }
}