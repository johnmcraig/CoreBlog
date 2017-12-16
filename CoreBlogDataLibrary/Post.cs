using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBlogDataLibrary
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Permalink { get; set; }
        public Author PostAuthor { get; set; }
        public string PostContent { get; set; }
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EditDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        
    }
}
