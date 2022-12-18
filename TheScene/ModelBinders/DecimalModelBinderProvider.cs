// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-01-2022
//
// Last Modified By : Admin
// Last Modified On : 12-07-2022
// ***********************************************************************
// <copyright file="DecimalModelBinderProvider.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheScene.ModelBinders
{
    /// <summary>
    /// Class DecimalModelBinderProvider.
    /// Implements the <see cref="IModelBinderProvider" />
    /// </summary>
    /// <seealso cref="IModelBinderProvider" />
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// Gets the binder.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>System.Nullable&lt;IModelBinder&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Decimal)
             || context.Metadata.ModelType == typeof(Decimal?)
             || context.Metadata.ModelType == typeof(Double)
             || context.Metadata.ModelType == typeof(Double?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }
}
