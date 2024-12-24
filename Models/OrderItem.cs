using System;
using System.Collections.Generic;

namespace laba.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArtworkId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Artwork Artwork { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
