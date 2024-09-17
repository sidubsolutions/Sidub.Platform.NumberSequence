/*
 * Sidub Platform - Number Sequence
 * Copyright (C) 2024 Sidub Inc.
 * All rights reserved.
 *
 * This file is part of Sidub Platform - Number Sequence (the "Product").
 *
 * The Product is dual-licensed under:
 * 1. The GNU Affero General Public License version 3 (AGPLv3)
 * 2. Sidub Inc.'s Proprietary Software License Agreement (PSLA)
 *
 * You may choose to use, redistribute, and/or modify the Product under
 * the terms of either license.
 *
 * The Product is provided "AS IS" and "AS AVAILABLE," without any
 * warranties or conditions of any kind, either express or implied, including
 * but not limited to implied warranties or conditions of merchantability and
 * fitness for a particular purpose. See the applicable license for more
 * details.
 *
 * See the LICENSE.txt file for detailed license terms and conditions or
 * visit https://sidub.ca/licensing for a copy of the license texts.
 */

namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Provides sequential number sequence capabilities; that is a sequence that increments
    /// based on a current value.
    /// </summary>
    public class SequentialNumberSequenceProvider : INumberSequenceProvider
    {

        #region Public methods

        /// <summary>
        /// Gets the next value in the sequential number sequence.
        /// </summary>
        /// <typeparam name="T">The type of the number sequence value.</typeparam>
        /// <param name="options">The number sequence options.</param>
        /// <returns>The next value in the sequential number sequence.</returns>
        public async Task<NumberSequenceValue<T>> GetValue<T>(INumberSequenceOptions options)
        {
            if (options is null)
                throw new ArgumentException(nameof(options), "A non-null SequentialNumberSequenceOptions must be provided.");
            else if (options is not SequentialNumberSequenceOptions<T>)
            {
                if (options.GetType().GetGenericTypeDefinition() == typeof(SequentialNumberSequenceOptions<>))
                    throw new ArgumentException(nameof(options), $"Incorrect options type provided; requested type '{typeof(T)}' but options type '{options.GetType().GenericTypeArguments.Single()}'.");
                else
                    throw new ArgumentException(nameof(options), $"Invalid options type '{options.GetType().Name}' provided.");
            }

            var sequentialNumberOptions = options as SequentialNumberSequenceOptions<T> ?? throw new Exception($"Invalid options type '{options?.GetType().Name}' provided.");

            NumberSequenceValue<T> numberSequenceValue = await sequentialNumberOptions.StateProvider.GetNextValue();
            await sequentialNumberOptions.StateProvider.SetCurrentValue(numberSequenceValue);

            return numberSequenceValue;
        }

        #endregion

    }

}
