using System;
using System.Collections.Generic;

namespace Movies_PRN211.Models
{
    public partial class Comment
    {
        public int Cid { get; set; }
        public string Comment1 { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Name { get; set; } = null!;
        public int Id { get; set; }

        public virtual Movie IdNavigation { get; set; } = null!;
    }
}
