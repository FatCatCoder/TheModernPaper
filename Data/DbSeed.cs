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

            if (context.Users!.Any() && context.Articles!.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User
                (
                    "Jane Doe", // name
                    "janedoe@email.com", // email
                    "password", // password
                    false // pro
                ),
                new User
                (
                    "John Smith",
                    "johnsmith@email.com",
                    "password",
                    true
                )
            };

            foreach (User person in users)
            {
                context.Users.Add(person);
            }
            context.SaveChanges();

            var posts = new Article[]
            {
                new Article
                (
                    "ASP.net Core, The Future of Microsoft and the Beauty of Open Source",
                    users.Single( i => i.Name == "John Smith").Id,
                    new List<string> {"asp.net", "c#", "web framework", "open source"},
                    "ASP.net Core 6, Is a great open source web framework developed by microsoft."
                ),
                new Article
                (
                    "Node.js vs ASP.net Core pros and cons for rapid web api development",
                    users.Single( i => i.Name == "John Smith").Id,
                    new List<string> {"asp.net", "c#", "web framework", "open source", "javascript", "node", "js", "node.js"},
                    "Today we will discuss the pros and cons of using ASP.net over Node.js and vice versea."
                ),
                new Article
                (
                    "How to move to the cloud (serverless) to save running costs and headaches",
                    users.Single( i => i.Name == "John Smith").Id,
                    new List<string> {"cloud", "devops", "azure", "serverless", "aws"},
                    "Now not \"owning\" your server sounds scary but the world of serverless and its benefits is omnipresent within the modern tech stack. Ask any DevOps leader how much they've saved and how eager they are to go back to using a hammer for the computer and their head."
                ),
                new Article
                (
                    "The ONE things you must know about React.js",
                    users.Single( i => i.Name == "John Smith").Id,
                    new List<string> {"open source", "javascript", "js", "react", "react.js", "clickbait", "tips"},
                    "React.js is super awesome and you totaly should look into it."
                ),
                new Article
                (
                    "RESTful vs GraphQL",
                    users.Single( i => i.Name == "John Smith").Id,
                    new List<string> {"api", "rest", "grahpql", "design", "restful"},
                    "A lot of good can be said about both API langauge specifications, but in the end its up your data requirements on which one allows the most efficient communication of client-server."
                )
            };

            foreach (Article post in posts)
            {
                context.Articles.Add(post);
                // TODO: map new post to users' list of written articles
            }
            context.SaveChanges();

        }
    }
}