using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Checkout> Checkouts { get; set; }
    }
}