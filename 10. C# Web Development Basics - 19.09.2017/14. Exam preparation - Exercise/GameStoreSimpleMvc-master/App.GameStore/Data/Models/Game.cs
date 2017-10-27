﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.GameStore.Data.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Infrastructure.Validation.Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue)]
        public double Size { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string VideoId { get; set; }

        public string ThumbnailUrl { get; set; }

        [Infrastructure.Validation.Required]
        [MinLength(20)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<Order> Users { get; set; } = new List<Order>();
    }
}