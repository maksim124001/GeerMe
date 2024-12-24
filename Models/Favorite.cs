using System;
using System.Collections.Generic;

namespace laba.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArtworkId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Artwork Artwork { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
