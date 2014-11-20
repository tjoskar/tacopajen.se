﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tacopajen.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Guid RecipeId { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}