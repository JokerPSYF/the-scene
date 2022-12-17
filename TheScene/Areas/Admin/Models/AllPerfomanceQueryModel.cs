// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-16-2022
//
// Last Modified By : Admin
// Last Modified On : 12-16-2022
// ***********************************************************************
// <copyright file="AllPerfomanceQueryModel.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using TheScene.Core.Models.PerfomanceModels;

namespace TheScene.Models
{
    /// <summary>
    /// Class AllPerfomanceQueryModel.
    /// </summary>
    public class AllPerfomanceQueryModel
    {
        /// <summary>
        /// The perfomance per page
        /// </summary>
        public const int PerfomancePerPage = 6;

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        /// <value>The genre.</value>
        public string? Genre { get; set; }

        /// <summary>
        /// Gets or sets the type of the perfomance.
        /// </summary>
        /// <value>The type of the perfomance.</value>
        [Display(Name = "Type")]
        public string? PerfomanceType { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        /// <value>The search term.</value>
        [Display(Name = "Search")]
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        /// <value>The sorting.</value>
        public PerfomanceSotring Sorting { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// Gets or sets the total perfomance count.
        /// </summary>
        /// <value>The total perfomance count.</value>
        public int TotalPerfomanceCount { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>The genres.</value>
        public IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the perfomance types.
        /// </summary>
        /// <value>The perfomance types.</value>
        public IEnumerable<string> PerfomanceTypes { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the perfomances.
        /// </summary>
        /// <value>The perfomances.</value>
        public IEnumerable<AllPerfomanceModel> Perfomances { get; set; } = Enumerable.Empty<AllPerfomanceModel>();
    }
}