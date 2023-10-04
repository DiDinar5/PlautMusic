﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
