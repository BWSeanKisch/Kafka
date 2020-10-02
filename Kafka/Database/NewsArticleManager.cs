using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Kafka.Data;
using Kafka.Database.Entities;
using Microsoft.Ajax.Utilities;

namespace Kafka.Database
{
    /// <summary>
    ///     Static manager for handling NewsArticles CRUD operations
    /// </summary>
    public static class NewsArticleManager
    {
        /// <summary>
        /// Get news articles
        /// </summary>
        /// <returns>List of all articles</returns>
        public static List<NewsArticle> List()
        {
            using (var ctx = new NewsArticlesContext())
            {
                    return ctx.NewsArticles.ToList();
            }
        }
        public static NewsArticle Get(int id)
        {
            using (var ctx = new NewsArticlesContext())
            {
                return ctx.NewsArticles.SingleOrDefault(o => o.Id == id);
            }
        }

        public static void Update(NewsArticle item)
        {
            using (var ctx = new NewsArticlesContext())
            {
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public static NewsArticle UpdateOrCreate(NewsArticle item)
        {
            if (item.Id != 0)
            {
                Update(item);
                return item;
            }
            else
            {
                return CreateAndReturn(item);
            }

        }

        public static NewsArticle CreateAndReturn(NewsArticle item)
        {
            using (var ctx = new NewsArticlesContext())
            {
                ctx.NewsArticles.Add(item);
                ctx.SaveChanges();
            }

            return item;
        }
        public static void Delete(int id)
        {
            using (var ctx = new NewsArticlesContext())
            {
                var item = ctx.NewsArticles.SingleOrDefault(o => o.Id == id);
                if (item != null)
                {
                    ctx.NewsArticles.Attach(item);
                    ctx.NewsArticles.Remove(item);
                    ctx.SaveChanges();
                }
            }
        }
    }
}