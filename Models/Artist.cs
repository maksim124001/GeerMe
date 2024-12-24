using System;
using System.Collections.Generic;

namespace laba.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Artworks = new HashSet<Artwork>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Bio { get; set; }
        public string? PortfolioUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
