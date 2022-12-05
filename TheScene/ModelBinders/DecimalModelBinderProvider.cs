﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheScene.ModelBinders
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
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
