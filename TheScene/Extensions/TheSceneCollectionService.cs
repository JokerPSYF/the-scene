// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 11-12-2022
//
// Last Modified By : Admin
// Last Modified On : 12-17-2022
// ***********************************************************************
// <copyright file="TheSceneCollectionService.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using TheScene.Core.Interface;
using TheScene.Core.Service;
using TheScene.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class TheSceneCollectionService.
    /// </summary>
    public static class TheSceneCollectionService
    {
        /// <summary>
        /// Adds the aplication services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IPerfomanceService, PerfomanceService>();
            services.AddScoped<ILocationService, LocationService>();

            return services;
        }
    }
}
