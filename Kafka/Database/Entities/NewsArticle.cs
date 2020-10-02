using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kafka.Database.Entities
{
    public class NewsArticle
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Preamble { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}