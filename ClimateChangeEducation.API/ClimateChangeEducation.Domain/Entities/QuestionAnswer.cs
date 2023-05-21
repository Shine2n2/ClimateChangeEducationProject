﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AllocatedScore { get; set; }
        public bool IsCorrect { get; set; }
        public QuizQuestion QuestionId { get; set; }
        
    }
}
