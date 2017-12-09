using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoreBlogDataLibrary
{
    public class PostRepository
    {
        private static List<Post> _posts = new List<Post>();
        private static int _nextId = 1;
        private static string path = @"C:\Desktop\Projects\BlogRepo";
        private static string fileName = "postList.json";

        public PostRepository()
        {
            if(_posts.Count < 1)
            {
                LoadFromFile();
            }
        }

        public List<Post> List()
        {
            return _posts
                .Where(p => p.PublishDate <= DateTime.Now)
                .OrderByDescending(p => p.PublishDate)
                .ToList();
        }

        public List<Post> ListAll()
        {
            return _posts
                .OrderByDescending(p => p.PostDate)
                .ToList();
                
        }

        public Post GetById(int id)
        {
            return _posts
                .Find(p => p.Id == id);
        }

        public Post GetByPermalink(string permalink)
        {
            return _posts
                .Find(p => p.Permalink == permalink);
        }

        public void Add(Post newPost)
        {
            newPost.Id = _nextId++;
            if (newPost.PostAuthor == null)
            {
                newPost.PostAuthor = new Author();
            }
            _posts.Add(newPost);
            SaveToFile();
        }

        private void SaveToFile()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //manage nuget package under DataLibrary with newton.json to get it to work later.
            var serializedPosts = JsonConvert.SerializeObject(_posts);
            File.WriteAllText(Path.Combine(path, fileName), serializedPosts);
        }

        private void LoadFromFile()
        {
            if (!File.Exists(Path.Combine(path, fileName)))
            {
                return;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var serializedPosts = File.ReadAllText(Path.Combine(path, fileName));
            _posts = JsonConvert.DeserializeObject<List<Post>>(serializedPosts);
        }
    }
}
