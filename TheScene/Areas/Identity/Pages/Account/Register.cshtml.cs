// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-16-2022
//
// Last Modified By : Admin
// Last Modified On : 12-17-2022
// ***********************************************************************
// <copyright file="Register.cshtml.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TheScene.Infrastructure.Data;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Areas.Identity.Pages.Account
{
    /// <summary>
    /// Class RegisterModel.
    /// Implements the <see cref="PageModel" />
    /// </summary>
    /// <seealso cref="PageModel" />
    public class RegisterModel : PageModel
    {
        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<AppUser> _signInManager;
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<AppUser> _userManager;


        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterModel"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        /// directly from your code. This API may change or be removed in future releases.
        /// </summary>
        /// <value>The input.</value>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        /// directly from your code. This API may change or be removed in future releases.
        /// </summary>
        /// <value>The return URL.</value>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        /// directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {

            /// <summary>
            /// Gets or sets the first name.
            /// </summary>
            /// <value>The first name.</value>
            [Display(Name = "First Name")]
            [MaxLength(UserConstants.FNameMax/*, ErrorMessage = LengthErrorMessage*/)]
            public string? FirstName { get; set; }

            /// <summary>
            /// Gets or sets the last name.
            /// </summary>
            /// <value>The last name.</value>
            [Display(Name = "Last Name")]
            [MaxLength(UserConstants.LNameMax/*, ErrorMessage = LengthErrorMessage*/)]
            public string? LastName { get; set; }

            /// <summary>
            /// Gets or sets the username.
            /// </summary>
            /// <value>The username.</value>
            [Required]
            [MaxLength(UserConstants.UsernameMax/*, ErrorMessage = LengthErrorMessage*/)]
            public string Username { get; set; }



            /// <summary>
            /// This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            /// directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// <value>The email.</value>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            /// This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            /// directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// <value>The password.</value>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            /// This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            /// directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// <value>The confirm password.</value>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        /// <summary>
        /// On get as an asynchronous operation.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        /// <summary>
        /// On post as an asynchronous operation.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>A Task&lt;IActionResult&gt; representing the asynchronous operation.</returns>
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = Input.Username,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
