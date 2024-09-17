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
    /// Represents a provider for managing the state of a sequential number sequence.
    /// </summary>
    /// <typeparam name="TValue">The type of the number sequence value.</typeparam>
    public interface ISequentialNumberSequenceStateProvider<TValue>
    {

        #region Interface methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence, or null if the value is not available.</returns>
        Task<NumberSequenceValue<TValue>?> GetCurrentValue();

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The new value to set.</param>
        Task SetCurrentValue(NumberSequenceValue<TValue> value);

        /// <summary>
        /// Gets the next value of the number sequence.
        /// </summary>
        /// <returns>The next value of the number sequence.</returns>
        Task<NumberSequenceValue<TValue>> GetNextValue();

        #endregion

    }

}
