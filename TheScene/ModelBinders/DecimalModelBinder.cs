// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-01-2022
//
// Last Modified By : Admin
// Last Modified On : 12-01-2022
// ***********************************************************************
// <copyright file="DecimalModelBinder.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace TheScene.ModelBinders
{
    /// <summary>
    /// Class DecimalModelBinder.
    /// Implements the <see cref="IModelBinder" />
    /// </summary>
    /// <seealso cref="IModelBinder" />
    public class DecimalModelBinder : IModelBinder
    {
        /// <summary>
        /// Binds the model asynchronous.
        /// </summary>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>Task.</returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal actualValue = 0M;
                bool success = false;

                try
                {
                    string decValue = valueResult.FirstValue;
                    decValue = decValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decValue = decValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    actualValue = Convert.ToDecimal(decValue, CultureInfo.CurrentCulture);
                    success = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualValue);
                }
            }

            return Task.CompletedTask;
        }
    }
}
