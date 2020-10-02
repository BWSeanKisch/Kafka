using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kafka.Database.Entities;

namespace Kafka.Data
{
    public class NewsArticlesContext: DbContext
    {
        public NewsArticlesContext() : base("KafkaDbString")
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NewsArticlesContext>());
        }
        public DbSet<NewsArticle> NewsArticles { get; set; }
    }
}