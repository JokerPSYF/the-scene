// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-16-2022
//
// Last Modified By : Admin
// Last Modified On : 12-17-2022
// ***********************************************************************
// <copyright file="AllEventsQueryModel.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using TheScene.Models;

namespace TheScene.Areas.Admin.Models
{
    /// <summary>
    /// All Events, the admin can
    /// </summary>
    public class AllEventsQueryModel : EventsQueryModel
    {
        /// <summary>
        /// Gets or sets the perfomance types.
        /// </summary>
        /// <value>The perfomance types.</value>
        public IEnumerable<string> PerfomanceTypes { get; set; } = Enumerable.Empty<string>();
    }
}
