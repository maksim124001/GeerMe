using System;
using System.Collections.Generic;

namespace laba.Models
{
    public partial class Artwork
    {
        public Artwork()
        {
            ArtworkImages = new HashSet<ArtworkImage>();
            Favorites = new HashSet<Favorite>();
            OrderItems = new HashSet<OrderItem>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual Artist Artist { get; set; } = null!;
        public virtual ICollection<ArtworkImage> ArtworkImages { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
