// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-16-2022
//
// Last Modified By : Admin
// Last Modified On : 12-17-2022
// ***********************************************************************
// <copyright file="EventsQueryModel.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using TheScene.Core.Models.Event;

namespace TheScene.Models
{
    /// <summary>
    /// Class EventsQueryModel.
    /// </summary>
    public class EventsQueryModel
    {
        /// <summary>
        /// The events per page
        /// </summary>
        public const int EventsPerPage = 6;

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        /// <value>The genre.</value>
        public string? Genre { get; set; }

        /// <summary>
        /// Gets or sets the type of the perfomance.
        /// </summary>
        /// <value>The type of the perfomance.</value>
        [Display(Name = "Perfomance Type")]
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
        public EventSorting Sorting { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// Gets or sets the total events count.
        /// </summary>
        /// <value>The total events count.</value>
        public int TotalEventsCount { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>The genres.</value>
        public IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        public IEnumerable<AllEventModel> Events { get; set; } = Enumerable.Empty<AllEventModel>();
    }
}
