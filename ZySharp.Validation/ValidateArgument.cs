﻿using System;

using JetBrains.Annotations;

namespace ZySharp.Validation
{
    /// <summary>
    /// Provides various methods for basic argument validation.
    /// </summary>
    public static partial class ValidateArgument
    {
        /// <summary>
        /// Selects an argument for validation.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <param name="name">The name of the argument to validate.</param>
        /// <param name="action">The action to perform for the selected parameter.</param>
        /// <returns>The value of the validated argument.</returns>
        public static T? For<T>([ValidatedNotNull][NoEnumeration] T? value, string name, Action<IValidatorContext<T?>> action)
        {
            ValidationInternals.ValidateNotNull(name, nameof(name));
            ValidationInternals.ValidateNotNull(action, nameof(action));

            var context = new ValidatorContext<T?>(value, name);
            action(context);

            if (context.Exception is null)
            {
                return value;
            }

            try
            {
                throw context.Exception;
            }
            catch (Exception e)
            {
                ValidationInternals.RemoveStackFrame(e);
                throw;
            }
        }
    }
}