using System;
using System.Collections.Generic;

namespace Movies_PRN211.Models
{
    public partial class Cmt
    {
        public int Cid { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Name { get; set; } = null!;
        public int Id { get; set; }

        public virtual Comment CidNavigation { get; set; } = null!;
    }
}
