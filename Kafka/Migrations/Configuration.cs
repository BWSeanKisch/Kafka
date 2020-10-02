using System.Collections.Generic;
using Kafka.Database.Entities;

namespace Kafka.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kafka.Data.NewsArticlesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Kafka.Data.NewsArticlesContext context)
        {
            var posts = new List<NewsArticle>
            {
                new NewsArticle {
        Title = "It showed a lady fitted out with a fur hat and fur boa who sat upright",
        Preamble = "Gregor then turned to look out the window at the dull weather. Drops of rain could be heard hitting the pane, which made him feel quite sad. How about if I sleep a little bit longer and forget all this nonsense...",
        Image = "media/image01.jpg",
        Date = new DateTime(2020,05,26),
        Category = "kafka"

    },
    new NewsArticle {
        Title = "Kafka is turning into a bug!",
        Preamble = "Gregor then turned to look out the window at the dull weather. Drops of rain could be heard hitting the pane, which made him feel quite sad.",
        Image = "media/image02.jpg",
        Date = new DateTime(2020,05,21),
        Category = "kafka"
    },
    new NewsArticle {
        Title = "What's happened to me?",
        Preamble = "It wasn't a dream. His room, a proper human room although a little too small, lay peacefully between its four familiar walls.",
        Image = "media/image03.jpg",
        Date = new DateTime(2020,05,13),
        Category = "bug"
    },
    new NewsArticle {
        Title = "What a strenuous career it is that I've chosen!",
        Preamble = "Traveling day in and day out. Doing business like this takes much more effort than doing your own business at home, and on top of that there's the curse of traveling, worries about making train connections, bad...",
        Image = "media/image04.jpg",
        Date = new DateTime(2020,04,29),
        Category = "breaking news"
    },
    new NewsArticle {
        Title = "How about if I sleep a little bit longer and forget all this nonsense",
        Preamble = "but that was something he was unable to do because he was used to sleeping on his right, and in his present state couldn't get into that position.",
        Image = "media/image05.jpg",
        Date = new DateTime(2020,04,11),
        Category = "kafka"
    },
    new NewsArticle {
        Title = "Drops of rain could be heard hitting the pane",
        Preamble = "Well, there's still some hope; once I've got the money together to pay off my parents' debt to him - another five or six years I suppose - that's definitely what I'll do. That's when I'll make the big change",
        Image = "media/image06.jpg",
        Date = new DateTime(2020,04,02),
        Category = "breaking news"
    }
            };

            posts.ForEach(p => context.NewsArticles.Add(p));
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
