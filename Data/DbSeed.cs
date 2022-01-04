using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ModernPaper.Models;
using ModernPaper.Contexts;

namespace ModernPaper.Data
{
    public static class DbSeed
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Check if DB contains data
            // if (context.Users!.Any() && context.Articles!.Any())
            // {
            //     return;   // DB has been seeded
            // }

            var users = new User[]
            {
                new User
                {
                    Name = "Jane Doe",
                    Email = "janedoe@email.com",
                    Password = "password",
                    Pro = false
                },
                new User
                {
                    Name = "Austin Powers",
                    Email = "daddywasntthere@email.com",
                    Password = "mojo",
                    Pro = false
                },
                new User
                {
                    Name = "John Smith",
                    Email = "johnsmith@email.com",
                    Password = "password",
                    Pro = true
                }
            };

            foreach (User person in users)
            {
                context.Users.Add(person);
            }
            context.SaveChanges();


            var posts = new Article[]
            {
                new Article
                {
                    Title = "ASP.net Core, The Future of Microsoft and the Beauty of Open Source",
                    UserId = users.Single( i => i.Name == "John Smith").Id,
                    Keywords = new List<string> {"asp.net", "c#", "web framework", "open source"},
                    Content = "ASP.net Core 6, Is a great open source web framework developed by microsoft."
                },
                new Article
                {
                    Title = "Node.js vs ASP.net Core pros and cons for rapid web api development",
                    UserId = users.Single( i => i.Name == "John Smith").Id,
                    Keywords = new List<string> {"asp.net", "c#", "web framework", "open source", "javascript", "node", "js", "node.js"},
                    Content = "Today we will discuss the pros and cons of using ASP.net over Node.js and vice versea."
                },
                new Article
                {
                    Title = "How to move to the cloud (serverless) to save running costs and headaches",
                    UserId = users.Single( i => i.Name == "John Smith").Id,
                    Keywords = new List<string> {"cloud", "devops", "azure", "serverless", "aws"},
                    Content = "Not \"owning\" your server sounds scary but the world of serverless and its benefits are omnipresent within the modern tech stack. Ask any DevOps leader how much they've saved and how eager they are to go back to using a hammer for the computer and their head."
                },
                new Article
                {
                    Title = "The ONE thing you must know about React.js",
                    UserId = users.Single( i => i.Name == "John Smith").Id,
                    Keywords = new List<string> {"open source", "javascript", "js", "react", "react.js", "clickbait", "tips"},
                    Content = "React.js is super awesome and you totaly should look into it."
                },
                new Article
                {
                    Title = "RESTful vs GraphQL",
                    UserId = users.Single( i => i.Name == "John Smith").Id,
                    Keywords = new List<string> {"api", "rest", "grahpql", "design", "restful"},
                    Content = "A lot of good can be said about both API langauge specifications, but in the end its up your data requirements on which one allows the most efficient communication of client-server."
                }
            };

            foreach (Article post in posts)
            {
                context.Articles.Add(post);
            }

            context.SaveChanges();
        }
    }
}