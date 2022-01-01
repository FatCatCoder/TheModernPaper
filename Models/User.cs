using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModernPaper.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool Pro { get; set; }

        public ICollection<Article>? Articles { get; set; }

        // public User(string name, string email, string password, bool pro)
        // {
        //     Name = name;
        //     Email = email;
        //     Password = password;
        //     Pro = Pro;
        // } 
    }      
}