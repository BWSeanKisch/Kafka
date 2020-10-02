using System;
using System.ComponentModel.DataAnnotations;

namespace Kafka.Models
{
    public class EditNewsArticleViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Preamble { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Category { get; set; }
    }
}