
using Microsoft.AspNetCore.Identity;

namespace Arkitektur.Entity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        //bunlarý yazmasamda gelir sadevce istedýgýmýz seyerý ekleme ýçýn glecek

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FullName => string.Join(" ",FirstName,LastName);
        public string? ImageUrl { get; set; }


    }
}
