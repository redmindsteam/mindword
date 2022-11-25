﻿using MindWord.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Domain.Entities
{
    public class Word : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Translate { get; set; } = string.Empty; 
        public int UserId { get; set; }
        public string AudioPath { get; set; } = string.Empty;
        public int CorrectCoins { get; set; }
        public int ErrorCoins { get; set; }
        public int CategoryId { get; set; }
    }
}