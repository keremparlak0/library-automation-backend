﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public record BookCreateDto
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; init; }

        [Required(ErrorMessage = "Author is required!")]
        [StringLength(50, MinimumLength = 6)]
        public string Author { get; init; }
    }
}
