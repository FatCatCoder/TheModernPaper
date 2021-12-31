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
                    "Jane Doe",
                    "janedoe@email.com",
                    "password",
                    false
                ),
                new User
                (
                    "John Smith", // name
                    "johnsmith@email.com", // email
                    "password", // password
                    true // pro
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
                )
            };
        }
    }
}