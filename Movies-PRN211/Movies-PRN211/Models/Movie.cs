using System;
using System.Collections.Generic;

namespace Movies_PRN211.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Img { get; set; } = null!;
        public int CaId { get; set; }
        public string Description { get; set; } = null!;
        public int? View { get; set; }
        public int? Year { get; set; }
        public string? Director { get; set; }

        public virtual Category Ca { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
