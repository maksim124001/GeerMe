using System;
using System.Collections.Generic;

namespace laba.Models
{
    public partial class User
    {
        public User()
        {
            Artists = new HashSet<Artist>();
            Favorites = new HashSet<Favorite>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
