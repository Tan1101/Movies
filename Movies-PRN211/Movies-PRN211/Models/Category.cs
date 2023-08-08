using System;
using System.Collections.Generic;

namespace Movies_PRN211.Models
{
    public partial class Category
    {
        public Category()
        {
            Movies = new HashSet<Movie>();
        }

        public int CaId { get; set; }
        public string CaName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
