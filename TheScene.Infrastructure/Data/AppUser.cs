using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Infrastructure.Data
{
    public class AppUser : IdentityUser
    {

        [Required]
        [Comment("The first name of the user")]
        [MaxLength(UserConstants.FNameMax, ErrorMessage = LengthErrorMessage)]
        public string? FirstName { get; set; }

        [Required]
        [Comment("The first name of the user")]
        [MaxLength(UserConstants.LNameMax, ErrorMessage = LengthErrorMessage)]
        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
