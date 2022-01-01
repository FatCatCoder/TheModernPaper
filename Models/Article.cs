using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernPaper.Models
{
    public class Article
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Column("Author")]
        public Guid UserId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        //public List<string> Keywords { get; set; }

        [Required]
        public string Content { get; set; }

        // public Article(string title, Guid userId, List<string> keywords, string content)
        // {
        //     Title = title;
        //     UserId = userId;
        //     Keywords = keywords;
        //     Content = content;
        // } 
    }       
}