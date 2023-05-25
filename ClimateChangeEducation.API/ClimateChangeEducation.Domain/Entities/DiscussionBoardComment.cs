﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class DiscussionBoardComment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Content { get; set; }
        public DateTime CommentedDate { get; set; }
        public ApplicationUser Author { get; set; }
        public DiscussionBoardPost PostId { get; set; }

    }
}
