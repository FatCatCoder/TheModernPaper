using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ModernPaper.Models
{
    public class Article
    {
        [Required]
        // [DefaultValue("gen_random_uuid()")]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public virtual User? User { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultValue("now()")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("now()")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public List<string> Keywords { get; set; }

        [Required]
        public string Content { get; set; }
    }       
}