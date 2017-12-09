using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoreBlogDataLibrary
{
    public class AuthorRepository
    {
        private static List<Author> _authors = new List<Author>();
        private static int _nextId = 1;
        private static string path = @"C:\Desktop\Projects\BlogRepo";
        private static string fileName = "authorList.json";

        public AuthorRepository()
        {
            if (_authors.Count < 1)
            {
                LoadFromFile();
            }
        }

        public List<Author> List()
        {
            return _authors;
                
        }

        
        public Author GetById(int id)
        {
            return _authors
                .Find(a => a.Id == id);
            //.Where(a => a.Id == id)
            //.FirstOrDefault();

        }

        public void Add(Author newAuthor)
        {
            newAuthor.Id = _nextId++;
            _authors.Add(newAuthor);
            SaveToFile();
        }

        private void SaveToFile()
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //manage nuget package under DataLibrary with newton.json to get it to work later.
            var serializedAuthors = JsonConvert.SerializeObject(_authors);
            File.WriteAllText(Path.Combine(path, fileName), serializedAuthors);
        }

        private void LoadFromFile()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(Path.Combine(path, fileName)))
            {
                return;
            }

            var serializedAuthors = File.ReadAllText(Path.Combine(path, fileName));
            _authors = JsonConvert.DeserializeObject<List<Author>>(serializedAuthors);
        }
    }
}
