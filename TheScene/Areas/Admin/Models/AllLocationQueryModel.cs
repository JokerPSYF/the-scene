// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-16-2022
//
// Last Modified By : Admin
// Last Modified On : 12-16-2022
// ***********************************************************************
// <copyright file="AllLocationQueryModel.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using TheScene.Core.Models.Location;

namespace TheScene.Models
{
    /// <summary>
    /// Class AllLocationQueryModel.
    /// </summary>
    public class AllLocationQueryModel
    {
        /// <summary>
        /// The locations per page
        /// </summary>
        public const int LocationsPerPage = 6;

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        /// <value>The search term.</value>
        [Display(Name = "Search")]
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// Gets or sets the total location count.
        /// </summary>
        /// <value>The total location count.</value>
        public int TotalLocationCount { get; set; }

        /// <summary>
        /// Gets or sets the type of the place.
        /// </summary>
        /// <value>The type of the place.</value>
        [Display(Name = "Place Type")]
        public string? PlaceType { get; set; }

        /// <summary>
        /// Gets or sets the place types.
        /// </summary>
        /// <value>The place types.</value>
        public IEnumerable<string> PlaceTypes { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>The locations.</value>
        public IEnumerable<LocationModel> Locations { get; set; } = Enumerable.Empty<LocationModel>();
    }
}
