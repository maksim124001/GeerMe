using System;
using System.Collections.Generic;

namespace laba.Models
{
    public partial class ArtworkImage
    {
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool? IsMainImage { get; set; }

        public virtual Artwork Artwork { get; set; } = null!;
    }
}
